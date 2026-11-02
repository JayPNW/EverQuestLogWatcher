namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You are encumbered!""")]
public record YouBecameEncumbered(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
