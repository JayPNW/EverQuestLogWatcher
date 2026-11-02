namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You vanish.""")]
public record YouBecameInvisible(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
