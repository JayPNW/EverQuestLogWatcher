namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ has left the group\.$""",
"""Dara has left the group.""")]
public record SomeoneElseLeftGroup(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
