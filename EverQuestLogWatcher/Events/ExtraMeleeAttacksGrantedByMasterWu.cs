namespace EverQuestLogWatcher;

[LogLinePattern(
"""^The spirit of Master Wu fills you!  You gain \d+ additional attack\(s\)\.$""",
"""The spirit of Master Wu fills you!  You gain 2 additional attack(s).""")]
public record ExtraMeleeAttacksGrantedByMasterWu(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
