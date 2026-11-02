namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Your spell fizzles!""")]
public record YourSpellFizzled(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
