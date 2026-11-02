namespace EverQuestLogWatcher;

[LogLinePattern(
"""^[^,]+ auctions, '.*'$""",
"""Elowen auctions, 'wts Seahorse Spine Bracelet'""")]
public record AuctionChatMessageFromSomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
