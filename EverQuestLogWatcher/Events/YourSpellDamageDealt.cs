namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You hit .+ for \d+ points? of \w+ damage by .+\.$""",
"""You hit a dar ghoul knight for 123 points of magic damage by Smiting Strike.""")]
public record YourSpellDamageDealt(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
