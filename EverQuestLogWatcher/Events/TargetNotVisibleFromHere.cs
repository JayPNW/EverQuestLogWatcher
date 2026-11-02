namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You can't see your target from here.""")]
public record TargetNotVisibleFromHere(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
