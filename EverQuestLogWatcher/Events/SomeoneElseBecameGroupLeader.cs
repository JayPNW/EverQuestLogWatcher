namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ is now the leader of your group\.$""",
"""Aldric is now the leader of your group.""")]
public record SomeoneElseBecameGroupLeader(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
