namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You cannot see your target.""")]
public record TargetNotVisible(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
