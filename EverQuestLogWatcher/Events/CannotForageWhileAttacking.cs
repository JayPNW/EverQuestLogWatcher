namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You can't try to forage while attacking.""")]
public record CannotForageWhileAttacking(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
