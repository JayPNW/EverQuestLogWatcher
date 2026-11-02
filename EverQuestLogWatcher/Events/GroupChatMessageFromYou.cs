namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You tell your party, '.*'$""",
"""You tell your party, 'pulling'""")]
public record GroupChatMessageFromYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
