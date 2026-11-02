namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You can't use that command right now...""")]
public record CommandUnavailableRightNow(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
