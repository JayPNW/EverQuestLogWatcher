namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You have been removed from the group.""")]
public record YouWereRemovedFromGroup(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
