namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You are stunned!""")]
public record YouWereStunned(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
