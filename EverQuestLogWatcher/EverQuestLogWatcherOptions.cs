namespace EverQuestLogWatcher;

public record EverQuestLogWatcherOptions
{
    public bool ReplayLinesAlreadyInLogWhenStarting { get; init; }

    public TimeSpan PollingInterval { get; init; } = TimeSpan.FromMilliseconds(250);
}
