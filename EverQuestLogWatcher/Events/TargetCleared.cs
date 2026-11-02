namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You no longer have a target.""")]
public record TargetCleared(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
