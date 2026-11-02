using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EverQuestLogWatcher;

/// <summary>Turns one line of a character's log, timestamp included, into an event.</summary>
public class EverQuestLogLineParser(Character character, SpellTextIndex spellTextIndex)
{
    static readonly Regex TimestampThenMessage = new("""^\[(?<Timestamp>[^\]]{1,26})\] (?<Message>.*)$""", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

    static readonly string[] TimestampFormats = ["ddd MMM dd HH:mm:ss yyyy", "ddd MMM d HH:mm:ss yyyy"];

    static readonly EventBoundFromPattern[] AllEventPatterns = [.. EventRules.InOrderTried.Select(eventType => new EventBoundFromPattern(eventType, eventType.GetCustomAttribute<LogLinePatternAttribute>()!))];

    public EverQuestLogLineParser(Character character) : this(character, SpellTextIndex.Empty)
    {
    }

    public EverQuestLogEvent Parse(string rawLogLine)
    {
        if (!TrySplitTimestampFromMessage(rawLogLine, out var localTimestamp, out var message))
        {
            return new Unrecognized(character, DateTime.Now, rawLogLine);
        }

        return EventFromPatterns(message, localTimestamp, rawLogLine)
               ?? EventFromSpellText(message, localTimestamp, rawLogLine)
               ?? new Unrecognized(character, localTimestamp, rawLogLine);
    }

    /// <summary>The first rule that matches wins, so a later rule may be more accepting than an earlier one.</summary>
    EverQuestLogEvent? EventFromPatterns(string message, DateTime localTimestamp, string rawLogLine)
    {
        foreach (var eventPattern in AllEventPatterns)
        {
            var match = eventPattern.RegexMatchingWholeMessage.Match(message);
            if (match.Success)
            {
                return eventPattern.CreateEvent(match, character, localTimestamp, rawLogLine);
            }
        }

        return null;
    }

    EverQuestLogEvent? EventFromSpellText(string message, DateTime localTimestamp, string rawLogLine)
    {
        var spellsThatWoreOff = spellTextIndex.SpellNamesWhoseWoreOffTextIs(message);
        if (spellsThatWoreOff != null)
        {
            return new SpellEffectOnYouFaded(character, localTimestamp, rawLogLine, message, spellsThatWoreOff);
        }

        var spellsThatLandedOnYou = spellTextIndex.SpellNamesWhoseCastOnYouTextIs(message);
        if (spellsThatLandedOnYou != null)
        {
            return new SpellLandedOnYou(character, localTimestamp, rawLogLine, spellsThatLandedOnYou);
        }

        var landedOnSomeoneElse = spellTextIndex.LongestCastOnOtherTextEnding(message);
        if (landedOnSomeoneElse is var (targetName, spellNames))
        {
            return new SpellLandedOnSomeoneElse(character, localTimestamp, rawLogLine, targetName, spellNames);
        }

        return null;
    }

    static bool TrySplitTimestampFromMessage(string rawLogLine, out DateTime localTimestamp, out string message)
    {
        localTimestamp = default;
        message = "";
        var match = TimestampThenMessage.Match(rawLogLine);
        if (!match.Success)
        {
            return false;
        }

        if (!DateTime.TryParseExact(match.Groups["Timestamp"].Value, TimestampFormats, CultureInfo.InvariantCulture, DateTimeStyles.AllowInnerWhite, out localTimestamp))
        {
            return false;
        }

        message = match.Groups["Message"].Value;
        return true;
    }
}
