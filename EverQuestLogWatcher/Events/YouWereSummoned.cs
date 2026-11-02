namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You have been summoned!""")]
public record YouWereSummoned(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
