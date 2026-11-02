namespace EverQuestLogWatcher;

[LogLinePattern(
"""^(?!YOU ).+ is \w+ by .+'s \w+ for \d+ points? of non-melee damage[.!]$""",
"""A Delve drake is burned by Brynna's flames for 45 points of non-melee damage.""")]
public record DamageShieldBetweenOthersHurtAttacker(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
