namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Auto attack on.""")]
public record AutoAttackTurnedOn(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
