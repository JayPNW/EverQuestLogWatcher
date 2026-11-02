#:package editorconfig@0.18.0
#:property PublishAot=false
// Applies .editorconfig end_of_line, charset (BOM or not) and insert_final_newline to every file git tracks or would track.
// Usage, from the repo root: dotnet run tools/normalize-line-endings.cs [-- --check]
using System.Diagnostics;
using System.Text;
using EditorConfig.Core;

var onlyCheck = args.Contains("--check");
var utf8Bom = Encoding.UTF8.GetPreamble();
var parser = new EditorConfigParser();
var changedFilePaths = new List<string>();

foreach (var relativePath in FilesGitTracksOrWouldTrack())
{
    var path = Path.GetFullPath(relativePath);
    if (!File.Exists(path))
    {
        continue;
    }

    var original = File.ReadAllBytes(path);
    if (Array.IndexOf(original, (byte)0) >= 0)
    {
        continue;
    }

    if (!IsValidUtf8(original))
    {
        Console.WriteLine($"skipped, not UTF-8: {relativePath}");
        continue;
    }

    var config = parser.Parse(path);
    var normalized = Normalized(original, config);
    if (normalized.AsSpan().SequenceEqual(original))
    {
        continue;
    }

    changedFilePaths.Add(relativePath);
    if (!onlyCheck)
    {
        File.WriteAllBytes(path, normalized);
    }
}

foreach (var changedFilePath in changedFilePaths)
{
    Console.WriteLine($"{(onlyCheck ? "needs normalizing" : "normalized")}: {changedFilePath}");
}

if (onlyCheck && changedFilePaths.Count > 0)
{
    return 1;
}

return 0;

byte[] Normalized(byte[] original, FileConfiguration config)
{
    var hasBom = original.AsSpan().StartsWith(utf8Bom);
    var text = Encoding.UTF8.GetString(original, hasBom ? utf8Bom.Length : 0, original.Length - (hasBom ? utf8Bom.Length : 0));

    var lineEnding = LineEndingOrNull(config.EndOfLine);
    if (lineEnding != null)
    {
        text = text.Replace("\r\n", "\n").Replace("\r", "\n");
        if (config.InsertFinalNewline == true && text.Length > 0 && !text.EndsWith('\n'))
        {
            text += "\n";
        }

        if (config.InsertFinalNewline == false)
        {
            text = text.TrimEnd('\n');
        }

        text = text.Replace("\n", lineEnding);
    }

    var shouldHaveBom = hasBom;
    if (config.Charset == Charset.UTF8BOM)
    {
        shouldHaveBom = true;
    }

    if (config.Charset == Charset.UTF8)
    {
        shouldHaveBom = false;
    }

    var body = Encoding.UTF8.GetBytes(text);
    if (!shouldHaveBom)
    {
        return body;
    }

    return [.. utf8Bom, .. body];
}

static bool IsValidUtf8(byte[] bytes)
{
    try
    {
        new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true).GetString(bytes);
        return true;
    }
    catch (DecoderFallbackException)
    {
        return false;
    }
}

static string? LineEndingOrNull(EndOfLine? endOfLine)
{
    return endOfLine switch
    {
        EndOfLine.LF => "\n",
        EndOfLine.CRLF => "\r\n",
        EndOfLine.CR => "\r",
        _ => null,
    };
}

static IEnumerable<string> FilesGitTracksOrWouldTrack()
{
    var git = Process.Start(new ProcessStartInfo("git", "ls-files --cached --others --exclude-standard")
    {
        RedirectStandardOutput = true,
    })!;
    var output = git.StandardOutput.ReadToEnd();
    git.WaitForExit();
    if (git.ExitCode != 0)
    {
        throw new InvalidOperationException("git ls-files failed; run from inside the repo");
    }

    return output.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(line => line.TrimEnd('\r'));
}
