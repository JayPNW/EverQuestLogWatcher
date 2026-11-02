namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You tell \w+:\d+, '.*'$""",
"""You tell General1:1, 'lfg'""")]
public record NumberedChannelChatMessageFromYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
