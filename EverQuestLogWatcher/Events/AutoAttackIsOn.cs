namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Auto attack is on.""")]
public record AutoAttackIsOn(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
