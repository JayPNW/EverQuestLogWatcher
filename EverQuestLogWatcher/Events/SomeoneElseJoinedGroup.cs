namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ has joined the group\.$""",
"""Aldric has joined the group.""")]
public record SomeoneElseJoinedGroup(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
