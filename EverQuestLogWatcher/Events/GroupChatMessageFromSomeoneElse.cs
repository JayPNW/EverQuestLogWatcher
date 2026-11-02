namespace EverQuestLogWatcher;

[LogLinePattern(
"""^[^,]+ tells the group, '.*'$""",
"""Corwin tells the group, 'inc'""")]
public record GroupChatMessageFromSomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
