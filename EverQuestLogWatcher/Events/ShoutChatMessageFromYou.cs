namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You shout, '.*'$""",
"""You shout, 'help'""")]
public record ShoutChatMessageFromYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
