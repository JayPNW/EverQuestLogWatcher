namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You receive (?:(?:, | and )?(?:\d+ platinum|\d+ gold|\d+ silver|\d+ copper))+ as your split(?: \(with a bonus\))?\.$""",
"""You receive 2 platinum, 4 gold and 1 copper as your split (with a bonus).""")]
public record CoinSplitReceived(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
