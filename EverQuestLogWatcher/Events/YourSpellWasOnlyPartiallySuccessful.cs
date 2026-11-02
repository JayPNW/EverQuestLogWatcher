namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Your spell was partially successful.""")]
public record YourSpellWasOnlyPartiallySuccessful(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
