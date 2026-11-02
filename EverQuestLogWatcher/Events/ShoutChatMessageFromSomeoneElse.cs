namespace EverQuestLogWatcher;

[LogLinePattern(
"""^[^,]+ shouts, '.*'$""",
"""Elowen shouts, 'train to zone'""")]
public record ShoutChatMessageFromSomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
