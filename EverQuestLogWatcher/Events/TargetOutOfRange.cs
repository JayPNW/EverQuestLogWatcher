namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Your target is out of range, get closer!""")]
public record TargetOutOfRange(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
