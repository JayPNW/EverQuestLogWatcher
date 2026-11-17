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

    public static void WarnWhenEverQuestIsNotRunningOrLogging()
    {
        var watcher = new EverQuestLogWatcher();

        #region CheckRunningAndLogging
        var installs = watcher.FindRunningInstalls();
        if (installs.Count == 0)
        {
            Console.WriteLine("EverQuest is not running.");
        }

        foreach (var install in installs.Where(i => !i.IsLoggingEnabled))
        {
            Console.WriteLine($"Logging is off for {install.InstallDirectory}. Type `/log on` in game.");
        }
        #endregion
    }
}
