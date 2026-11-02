namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You can't hit them from here.""")]
public record MeleeTargetOutOfReach(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
