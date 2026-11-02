namespace EverQuestLogWatcher;

[LogLinePattern(
"""^YOU are \w+ by .+'s \w+ for \d+ points? of non-melee damage[.!]$""",
"""YOU are burned by a Delve spellbinder's flames for 30 points of non-melee damage!""")]
public record DamageShieldHurtYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
