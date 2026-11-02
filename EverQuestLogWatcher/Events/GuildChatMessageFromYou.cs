namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You say to your guild, '.*'$""",
"""You say to your guild, 'brb'""")]
public record GuildChatMessageFromYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
