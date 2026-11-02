namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You receive .* from the corpse\.$""",
"""You receive 2 platinum, 1 silver and 5 copper from the corpse.""")]
public record LootedFromCorpse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
