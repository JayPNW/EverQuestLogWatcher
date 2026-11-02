namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Your target is too far away, get closer!""")]
public record TargetTooFarAway(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
