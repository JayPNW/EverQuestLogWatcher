namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You must first select a target for this spell!""")]
public record SpellNeedsTarget(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
