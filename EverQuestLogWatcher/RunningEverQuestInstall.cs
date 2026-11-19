using Microsoft.Extensions.Configuration;

namespace EverQuestLogWatcher;

/// <summary>An EverQuest install directory that a running <c>eqgame.exe</c> was started from.</summary>
/// <param name="InstallDirectory">The directory containing <c>eqgame.exe</c> and <c>eqclient.ini</c>.</param>
/// <param name="IsLoggingEnabled">Whether <c>eqclient.ini</c> turns logging on (<c>Log=1</c> or <c>Log=true</c> under <c>[Defaults]</c>). When false, EverQuest writes no log files, so no events will be raised for this install unless the player types <c>/log on</c>.</param>
public record RunningEverQuestInstall(string InstallDirectory, bool IsLoggingEnabled)
{
    internal static RunningEverQuestInstall FromInstallDirectory(string installDirectory)
    {
        return new RunningEverQuestInstall(installDirectory, IsLoggingEnabledIn(Path.Combine(installDirectory, "eqclient.ini")));
    }

    static bool IsLoggingEnabledIn(string eqclientIniPath)
    {
        if (!File.Exists(eqclientIniPath))
        {
            return false;
        }

        using var stream = new FileStream(eqclientIniPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
        var eqclientIni = new ConfigurationBuilder().AddIniStream(stream).Build();
        var value = eqclientIni["Defaults:Log"]?.Trim();
        return value == "1" || string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
    }
}
