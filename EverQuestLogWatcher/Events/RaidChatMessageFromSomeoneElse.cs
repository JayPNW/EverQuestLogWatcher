namespace EverQuestLogWatcher;

[LogLinePattern(
"""^[^,]+ tells the raid, '.*'$""",
"""Corwin tells the raid, 'go'""")]
public record RaidChatMessageFromSomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
