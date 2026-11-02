namespace EverQuestLogWatcher;

[LogLinePattern(
"""^[^,]+ says out of character, '.*'$""",
"""Ilsa says out of character, 'one of the monkle shackles'""")]
public record OutOfCharacterChatMessageFromSomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
