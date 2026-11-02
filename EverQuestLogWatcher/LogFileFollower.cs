using System.Runtime.CompilerServices;
using System.Text;

namespace EverQuestLogWatcher;

/// <summary>Reads complete lines as they are appended to a log file. Starts over if the file gets shorter.</summary>
class LogFileFollower(string logFilePath, bool startAtBeginningOfFile, TimeSpan pollingInterval)
{
    public async IAsyncEnumerable<string> FollowLinesAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        long positionOfNextUnreadByte = 0;
        if (!startAtBeginningOfFile)
        {
            positionOfNextUnreadByte = new FileInfo(logFilePath).Length;
        }

        var bytesOfIncompleteLine = new List<byte>();
        var buffer = new byte[64 * 1024];
        while (!cancellationToken.IsCancellationRequested)
        {
            var completeLines = new List<string>();
            try
            {
                using var stream = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
                if (stream.Length < positionOfNextUnreadByte)
                {
                    positionOfNextUnreadByte = 0;
                    bytesOfIncompleteLine.Clear();
                }

                stream.Position = positionOfNextUnreadByte;
                int bytesRead;
                while ((bytesRead = await stream.ReadAsync(buffer, cancellationToken)) > 0)
                {
                    positionOfNextUnreadByte += bytesRead;
                    SplitIntoCompleteLines(buffer.AsSpan(0, bytesRead), bytesOfIncompleteLine, completeLines);
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (IOException)
            {
            }

            foreach (var line in completeLines)
            {
                yield return line;
            }

            try
            {
                await Task.Delay(pollingInterval, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                yield break;
            }
        }
    }

    static void SplitIntoCompleteLines(ReadOnlySpan<byte> bytes, List<byte> bytesOfIncompleteLine, List<string> completeLines)
    {
        foreach (var currentByte in bytes)
        {
            if (currentByte != (byte)'\n')
            {
                bytesOfIncompleteLine.Add(currentByte);
                continue;
            }

            var line = Encoding.Latin1.GetString([.. bytesOfIncompleteLine]).TrimEnd('\r');
            bytesOfIncompleteLine.Clear();
            if (line.Length > 0)
            {
                completeLines.Add(line);
            }
        }
    }
}
