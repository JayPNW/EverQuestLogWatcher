namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You must stand perfectly still to hide!""")]
public record MustStandStillToHide(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
