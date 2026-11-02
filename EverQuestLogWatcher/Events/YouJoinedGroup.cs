namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You have joined the group.""")]
public record YouJoinedGroup(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
