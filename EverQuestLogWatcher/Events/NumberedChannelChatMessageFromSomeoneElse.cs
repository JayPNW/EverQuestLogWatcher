namespace EverQuestLogWatcher;

[LogLinePattern(
"""^[^,]+ tells \w+:\d+, '.*'$""",
"""Jorund tells General:1, '58 Rog LFG'""")]
public record NumberedChannelChatMessageFromSomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
