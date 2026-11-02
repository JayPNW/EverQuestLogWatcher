namespace EverQuestLogWatcher.Tests;

public static class ReadmeExample
{
    public static async Task WriteSlainMobsToConsole()
    {
        #region BasicExample
        var watcher = new EverQuestLogWatcher();

        await foreach (var logEvent in watcher.WatchAsync(new EverQuestLogWatcherOptions {/*...*/}))
        {
            if (logEvent is MobSlainByYou)
            {
                Console.WriteLine($"{logEvent.Character.Name} slew something: {logEvent.RawLogLine}");
            }
        }
        #endregion
    }
}
