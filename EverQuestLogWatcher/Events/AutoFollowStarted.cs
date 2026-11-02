namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You will now auto-follow .+\.$""",
"""You will now auto-follow Aldric.""")]
public record AutoFollowStarted(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
