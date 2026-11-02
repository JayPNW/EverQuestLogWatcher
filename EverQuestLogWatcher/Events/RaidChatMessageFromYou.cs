namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You tell your raid, '.*'$""",
"""You tell your raid, 'ready'""")]
public record RaidChatMessageFromYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
