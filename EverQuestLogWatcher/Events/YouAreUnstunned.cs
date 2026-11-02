namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You are unstunned.""")]
public record YouAreUnstunned(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
