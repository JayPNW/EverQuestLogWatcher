namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You are now the leader of your group.""")]
public record YouBecameGroupLeader(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
