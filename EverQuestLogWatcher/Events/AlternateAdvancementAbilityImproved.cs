namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You have improved .+ \d+ at a cost of \d+ ability points?\.$""",
"""You have improved Innate Spell Resistance 5 at a cost of 0 ability points.""")]
public record AlternateAdvancementAbilityImproved(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
