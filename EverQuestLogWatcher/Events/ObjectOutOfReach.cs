namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You can't reach that, get closer.""")]
public record ObjectOutOfReach(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
