using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace EverQuestLogWatcher;

public record Character(string Name, string Server)
{
    /// <summary>Reads a log file name like <c>eqlog_Rowan_fangbreaker.txt</c>. Null for any other file name.</summary>
    public static Character? FromLogFileNameOrNull(string logFilePath)
    {
        var match = LogFileNameWithoutExtension.Match(Path.GetFileNameWithoutExtension(logFilePath));
        if (!match.Success)
        {
            return null;
        }

        return new Character(match.Groups["Name"].Value, match.Groups["Server"].Value);
    }

    static readonly Regex LogFileNameWithoutExtension = new("""^eqlog_(?<Name>[^_]+)_(?<Server>.+)$""", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
}

public class EverQuestLogWatcher
{
    readonly Func<IReadOnlyList<string>> findEverQuestInstallDirectories;

    public EverQuestLogWatcher() : this(RunningEverQuestClients.FindInstallDirectories)
    {
    }

    internal EverQuestLogWatcher(Func<IReadOnlyList<string>> findEverQuestInstallDirectories)
    {
        this.findEverQuestInstallDirectories = findEverQuestInstallDirectories;
    }

    public async IAsyncEnumerable<EverQuestLogEvent> WatchAsync(EverQuestLogWatcherOptions? options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        options ??= new EverQuestLogWatcherOptions();
        using var stopFollowing = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var events = Channel.CreateUnbounded<EverQuestLogEvent>();
        var discovery = DiscoverAndFollowLogFilesAsync(options, events.Writer, stopFollowing.Token);
        try
        {
            await foreach (var logEvent in ReadUntilCancelledAsync(events.Reader, stopFollowing.Token))
            {
                yield return logEvent;
            }
        }
        finally
        {
            await stopFollowing.CancelAsync();
            await discovery;
        }
    }

    static async IAsyncEnumerable<EverQuestLogEvent> ReadUntilCancelledAsync(ChannelReader<EverQuestLogEvent> reader, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (true)
        {
            EverQuestLogEvent logEvent;
            try
            {
                logEvent = await reader.ReadAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                yield break;
            }

            yield return logEvent;
        }
    }

    async Task DiscoverAndFollowLogFilesAsync(EverQuestLogWatcherOptions options, ChannelWriter<EverQuestLogEvent> events, CancellationToken cancellationToken)
    {
        var followedLogFilePaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var spellTextIndexByInstallDirectory = new Dictionary<string, SpellTextIndex>(StringComparer.OrdinalIgnoreCase);
        var followers = new List<Task>();
        var isFirstDiscovery = true;
        while (!cancellationToken.IsCancellationRequested)
        {
            foreach (var installDirectory in this.findEverQuestInstallDirectories())
            {
                foreach (var logFilePath in LogFilePathsIn(installDirectory))
                {
                    var character = Character.FromLogFileNameOrNull(logFilePath);
                    if (character == null || !followedLogFilePaths.Add(logFilePath))
                    {
                        continue;
                    }

                    if (!spellTextIndexByInstallDirectory.TryGetValue(installDirectory, out var spellTextIndex))
                    {
                        spellTextIndex = SpellTextIndex.LoadFromEverQuestInstallDirectory(installDirectory);
                        spellTextIndexByInstallDirectory[installDirectory] = spellTextIndex;
                    }

                    var logFileExistedWhenWatchingStarted = isFirstDiscovery;
                    var startAtBeginningOfFile = !logFileExistedWhenWatchingStarted || options.ReplayLinesAlreadyInLogWhenStarting;
                    var follower = new LogFileFollower(logFilePath, startAtBeginningOfFile, options.PollingInterval);
                    followers.Add(ParseFollowedLinesAsync(follower, new EverQuestLogLineParser(character, spellTextIndex), events, cancellationToken));
                }
            }

            isFirstDiscovery = false;
            try
            {
                await Task.Delay(options.PollingInterval, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }

        await Task.WhenAll(followers);
    }

    static async Task ParseFollowedLinesAsync(LogFileFollower follower, EverQuestLogLineParser parser, ChannelWriter<EverQuestLogEvent> events, CancellationToken cancellationToken)
    {
        await foreach (var line in follower.FollowLinesAsync(cancellationToken))
        {
            await events.WriteAsync(parser.Parse(line), CancellationToken.None);
        }
    }

    static IEnumerable<string> LogFilePathsIn(string installDirectory)
    {
        var logsDirectory = Path.Combine(installDirectory, "Logs");
        if (!Directory.Exists(logsDirectory))
        {
            return [];
        }

        return Directory.EnumerateFiles(logsDirectory, "eqlog_*.txt");
    }
}
