using System.ComponentModel;
using System.Diagnostics;

namespace EverQuestLogWatcher;

static class RunningEverQuestClients
{
    public static IReadOnlyList<string> FindInstallDirectories()
    {
        var installDirectories = new List<string>();
        foreach (var process in Process.GetProcessesByName("eqgame"))
        {
            using (process)
            {
                var installDirectory = InstallDirectoryOrNull(process);
                if (installDirectory != null && !installDirectories.Contains(installDirectory, StringComparer.OrdinalIgnoreCase))
                {
                    installDirectories.Add(installDirectory);
                }
            }
        }

        return installDirectories;
    }

    static string? InstallDirectoryOrNull(Process process)
    {
        try
        {
            var executablePath = process.MainModule?.FileName;
            if (executablePath == null)
            {
                return null;
            }

            return Path.GetDirectoryName(executablePath);
        }
        catch (Win32Exception)
        {
            return null;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
}
