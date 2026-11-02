namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You can't cast spells while stunned!""")]
public record CannotCastWhileStunned(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
