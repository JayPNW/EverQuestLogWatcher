namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You have slain .+!$""",
"""You have slain a Valorian Guardian!""")]
public record MobSlainByYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
