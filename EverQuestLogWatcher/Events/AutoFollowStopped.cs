namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You are no longer auto-following .+\.$""",
"""You are no longer auto-following Aldric.""")]
public record AutoFollowStopped(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
