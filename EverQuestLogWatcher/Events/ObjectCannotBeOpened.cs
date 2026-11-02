namespace EverQuestLogWatcher;

[LogLineLiteral(
"""That is not an object you can open.""")]
public record ObjectCannotBeOpened(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
