namespace EverQuestLogWatcher;

[LogLinePattern(
"""^[^,]+ tells the guild, '.*'$""",
"""Dara tells the guild, 'grats'""")]
public record GuildChatMessageFromSomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
