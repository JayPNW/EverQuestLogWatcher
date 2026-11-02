namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You must stand up and be still to perform this action.""")]
public record MustStandStillToPerformAction(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
