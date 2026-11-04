namespace EverQuestLogWatcher.Tests;

public class EverQuestLogWatcherTests : IDisposable
{
    readonly string installDirectory = Path.Combine(Path.GetTempPath(), "EverQuestLogWatcherTests", Guid.NewGuid().ToString());
    readonly string logsDirectory;

    public EverQuestLogWatcherTests()
    {
        this.logsDirectory = Path.Combine(this.installDirectory, "Logs");
        Directory.CreateDirectory(this.logsDirectory);
    }

    public void Dispose()
    {
        Directory.Delete(this.installDirectory, recursive: true);
    }

    static EverQuestLogWatcherOptions OptionsWithFastPolling(bool replayLinesAlreadyInLog)
    {
        return new EverQuestLogWatcherOptions
        {
            ReplayLinesAlreadyInLogWhenStarting = replayLinesAlreadyInLog,
            PollingInterval = TimeSpan.FromMilliseconds(20),
        };
    }

    void AppendToLog(string logFileName, string text)
    {
        File.AppendAllText(Path.Combine(this.logsDirectory, logFileName), text);
    }

    Task<List<EverQuestLogEvent>> WatchUntilCountReached(EverQuestLogWatcherOptions options, int expectedEventCount, Func<Task> whileWatching)
    {
        return WatchUntilCountReached(options, expectedEventCount, whileWatching, () => [this.installDirectory]);
    }

    static async Task<List<EverQuestLogEvent>> WatchUntilCountReached(EverQuestLogWatcherOptions options, int expectedEventCount, Func<Task> whileWatching, Func<IReadOnlyList<string>> findEverQuestInstallDirectories)
    {
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var received = new List<EverQuestLogEvent>();
        var watching = Task.Run(async () =>
        {
            await foreach (var logEvent in new EverQuestLogWatcher(findEverQuestInstallDirectories).WatchAsync(options, timeout.Token))
            {
                received.Add(logEvent);
                if (received.Count == expectedEventCount)
                {
                    break;
                }
            }
        });
        await Task.Delay(200);
        await whileWatching();
        await watching;
        return received;
    }

    [Fact]
    public async Task LinesAppendedAfterStartingAreRaised()
    {
        AppendToLog("eqlog_Rowan_fangbreaker.txt", "[Mon Sep 14 13:00:00 2026] You vanish.\r\n");

        var received = await WatchUntilCountReached(OptionsWithFastPolling(replayLinesAlreadyInLog: false), 1, () =>
        {
            AppendToLog("eqlog_Rowan_fangbreaker.txt", "[Mon Sep 14 13:00:01 2026] You appear.\r\n");
            return Task.CompletedTask;
        });

        var logEvent = Assert.Single(received);
        Assert.IsType<YouBecameVisible>(logEvent);
        Assert.Equal(new Character("Rowan", "fangbreaker"), logEvent.Character);
    }

    [Fact]
    public async Task ReplayRaisesLinesAlreadyInLog()
    {
        AppendToLog("eqlog_Rowan_fangbreaker.txt", "[Mon Sep 14 13:00:00 2026] You vanish.\r\n");

        var received = await WatchUntilCountReached(OptionsWithFastPolling(replayLinesAlreadyInLog: true), 1, () => Task.CompletedTask);

        Assert.IsType<YouBecameInvisible>(Assert.Single(received));
    }

    [Fact]
    public async Task LineIsRaisedOnlyOnceItIsComplete()
    {
        AppendToLog("eqlog_Rowan_fangbreaker.txt", "");

        var received = await WatchUntilCountReached(OptionsWithFastPolling(replayLinesAlreadyInLog: false), 1, async () =>
        {
            AppendToLog("eqlog_Rowan_fangbreaker.txt", "[Mon Sep 14 13:00:01 2026] You ");
            await Task.Delay(100);
            AppendToLog("eqlog_Rowan_fangbreaker.txt", "appear.\r\n");
        });

        Assert.IsType<YouBecameVisible>(Assert.Single(received));
    }

    [Fact]
    public async Task LogFileFoundAfterStartingIsFollowedFromItsEnd()
    {
        AppendToLog("eqlog_Rowan_fangbreaker.txt", "[Mon Sep 14 13:00:00 2026] You vanish.\r\n");
        var everQuestIsRunning = false;

        var received = await WatchUntilCountReached(OptionsWithFastPolling(replayLinesAlreadyInLog: false), 1, async () =>
        {
            everQuestIsRunning = true;
            await Task.Delay(200);
            AppendToLog("eqlog_Rowan_fangbreaker.txt", "[Mon Sep 14 13:00:01 2026] You appear.\r\n");
        }, () => everQuestIsRunning ? [this.installDirectory] : []);

        Assert.IsType<YouBecameVisible>(Assert.Single(received));
    }

    [Fact]
    public void CharacterComesFromLogFileName()
    {
        Assert.Equal(new Character("Rowan", "fangbreaker"), Character.FromLogFileNameOrNull(@"C:\EQ\Logs\eqlog_Rowan_fangbreaker.txt"));
        Assert.Equal(new Character("Sorrel", "project1999"), Character.FromLogFileNameOrNull("eqlog_Sorrel_project1999.txt"));
        Assert.Null(Character.FromLogFileNameOrNull("dbg.txt"));
        Assert.Null(Character.FromLogFileNameOrNull("eqlog_.txt"));
    }
}
