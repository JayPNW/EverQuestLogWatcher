namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Auto attack off.""")]
public record AutoAttackTurnedOff(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
