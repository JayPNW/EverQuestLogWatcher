namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You do not have a pet.""")]
public record YouHaveNoPet(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
