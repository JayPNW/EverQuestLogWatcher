namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You are too distracted to perform this action at this time.""")]
public record TooDistractedToPerformAction(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
