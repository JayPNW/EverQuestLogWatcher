namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You say, '.*'$""",
"""You say, 'hail'""")]
public record SayChatMessageFromYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
