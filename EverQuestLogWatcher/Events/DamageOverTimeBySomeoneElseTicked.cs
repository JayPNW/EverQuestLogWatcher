namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ (?:has|have) taken \d+ damage from (?!your ).+ by .+\.$""",
"""A Delve drake has taken 586 damage from Festering Darkness by Fenwick.""")]
public record DamageOverTimeBySomeoneElseTicked(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
