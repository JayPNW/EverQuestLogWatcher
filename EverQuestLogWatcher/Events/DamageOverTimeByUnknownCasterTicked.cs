namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ (?:has|have) taken \d+ damage by .+\.$""",
"""Garrick has taken 533 damage by Curse of Rhag`Zadune.""")]
public record DamageOverTimeByUnknownCasterTicked(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
