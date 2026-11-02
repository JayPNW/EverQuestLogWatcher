namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Auto attack is off.""")]
public record AutoAttackIsOff(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
