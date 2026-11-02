namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You auction, '.*'$""",
"""You auction, 'wtb bone chips'""")]
public record AuctionChatMessageFromYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
