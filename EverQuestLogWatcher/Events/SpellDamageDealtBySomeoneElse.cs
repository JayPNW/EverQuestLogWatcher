namespace EverQuestLogWatcher;

[LogLinePattern(
"""^(?!You ).+ hit .+ for \d+ points? of \w+ damage by .+\.$""",
"""Lyra hit a Delve drake for 1305 points of cold damage by Water Elemental Strike IV.""")]
public record SpellDamageDealtBySomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
