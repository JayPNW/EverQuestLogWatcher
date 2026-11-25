using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

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
        var executablePath = ExecutablePathOrNull(process.Id);
        return executablePath == null ? null : Path.GetDirectoryName(executablePath);
    }

    // Process.MainModule needs PROCESS_QUERY_INFORMATION | PROCESS_VM_READ, which a
    // non-elevated caller can't get on an elevated eqgame.exe. PROCESS_QUERY_LIMITED_INFORMATION
    // is allowed across integrity levels and is enough for QueryFullProcessImageName.
    static string? ExecutablePathOrNull(int processId)
    {
        using var handle = OpenProcess(ProcessQueryLimitedInformation, false, processId);
        if (handle.IsInvalid)
        {
            return null;
        }

        var buffer = new char[32768];
        var length = buffer.Length;
        return QueryFullProcessImageName(handle, 0, buffer, ref length)
            ? new string(buffer, 0, length)
            : null;
    }

    const uint ProcessQueryLimitedInformation = 0x1000;

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern SafeProcessHandle OpenProcess(uint desiredAccess, bool inheritHandle, int processId);

    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "QueryFullProcessImageNameW")]
    static extern bool QueryFullProcessImageName(SafeProcessHandle process, uint flags, [Out] char[] exeName, ref int size);
}
