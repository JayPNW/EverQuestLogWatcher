namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You are too distracted to cast a spell now!""")]
public record TooDistractedToCast(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
