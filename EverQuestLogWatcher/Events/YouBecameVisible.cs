namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You appear.""")]
public record YouBecameVisible(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
