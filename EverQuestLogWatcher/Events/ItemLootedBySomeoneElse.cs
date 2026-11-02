namespace EverQuestLogWatcher;

[LogLinePattern(
"""^--.+ has looted (?:a|an|\d+) .+ from .+'s corpse\.--$""",
"""--Brynna has looted 3 Drake Fang from a Delve drake's corpse.--""")]
public record ItemLootedBySomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
