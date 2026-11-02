namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You say out of character, '.*'$""",
"""You say out of character, 'lfg'""")]
public record OutOfCharacterChatMessageFromYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
