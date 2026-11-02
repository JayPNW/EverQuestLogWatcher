using System.Text;

namespace EverQuestLogWatcher;

public class SpellTextIndex
{
    public const int ShortestCastOnOtherTextTrusted = 14;

    public static SpellTextIndex Empty { get; } = new([], []);

    readonly Dictionary<string, List<string>> spellNamesByWoreOffText = new(StringComparer.Ordinal);
    readonly Dictionary<string, List<string>> spellNamesByCastOnYouText = new(StringComparer.Ordinal);
    readonly Dictionary<string, List<string>> spellNamesByTrustedCastOnOtherText = new(StringComparer.Ordinal);

    public SpellTextIndex(IEnumerable<string> spellsUsLines, IEnumerable<string> spellsUsStrLines)
    {
        var textsBySpellIndex = new Dictionary<string, string[]>(StringComparer.Ordinal);
        foreach (var line in spellsUsStrLines)
        {
            if (line.StartsWith('#'))
            {
                continue;
            }

            var fields = line.Split('^');
            if (fields.Length >= 6)
            {
                textsBySpellIndex[fields[0]] = fields;
            }
        }

        foreach (var line in spellsUsLines)
        {
            var fields = line.Split('^', 3);
            if (fields.Length < 2 || !textsBySpellIndex.TryGetValue(fields[0], out var texts))
            {
                continue;
            }

            var spellName = fields[1];
            AddSpellName(this.spellNamesByCastOnYouText, texts[3], spellName);
            AddSpellName(this.spellNamesByWoreOffText, texts[5], spellName);
            if (texts[4].Length >= ShortestCastOnOtherTextTrusted)
            {
                AddSpellName(this.spellNamesByTrustedCastOnOtherText, texts[4], spellName);
            }
        }
    }

    /// <summary>Returns <see cref="Empty"/> if either file is missing or unreadable.</summary>
    public static SpellTextIndex LoadFromEverQuestInstallDirectory(string everQuestInstallDirectory)
    {
        try
        {
            var latin1 = Encoding.Latin1;
            return new SpellTextIndex(
                File.ReadLines(Path.Combine(everQuestInstallDirectory, "spells_us.txt"), latin1),
                File.ReadLines(Path.Combine(everQuestInstallDirectory, "spells_us_str.txt"), latin1));
        }
        catch (IOException)
        {
            return Empty;
        }
        catch (UnauthorizedAccessException)
        {
            return Empty;
        }
    }

    public IReadOnlyList<string>? SpellNamesWhoseWoreOffTextIs(string message)
    {
        return this.spellNamesByWoreOffText.GetValueOrDefault(message);
    }

    public IReadOnlyList<string>? SpellNamesWhoseCastOnYouTextIs(string message)
    {
        return this.spellNamesByCastOnYouText.GetValueOrDefault(message);
    }

    /// <summary>The longest trusted cast-on-other text that ends the message, with something before it.</summary>
    public (string TargetName, IReadOnlyList<string> SpellNames)? LongestCastOnOtherTextEnding(string message)
    {
        for (var start = 1; start <= message.Length - ShortestCastOnOtherTextTrusted; start++)
        {
            var textCanStartHere = message[start] is ' ' or '\'';
            if (!textCanStartHere)
            {
                continue;
            }

            if (this.spellNamesByTrustedCastOnOtherText.TryGetValue(message[start..], out var spellNames))
            {
                return (message[..start], spellNames);
            }
        }

        return null;
    }

    static void AddSpellName(Dictionary<string, List<string>> spellNamesByText, string text, string spellName)
    {
        if (text.Length == 0)
        {
            return;
        }

        if (!spellNamesByText.TryGetValue(text, out var spellNames))
        {
            spellNames = [];
            spellNamesByText[text] = spellNames;
        }

        if (!spellNames.Contains(spellName))
        {
            spellNames.Add(spellName);
        }
    }
}
