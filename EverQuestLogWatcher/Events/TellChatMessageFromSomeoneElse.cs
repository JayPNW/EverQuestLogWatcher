namespace EverQuestLogWatcher;

[LogLinePattern(
"""^[^,]+ (?:tells|told) you, '.*'$""",
"""Kestrel told you, 'omw'""",
"""Kestrel tells you, 'omw'""")]
public record TellChatMessageFromSomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
