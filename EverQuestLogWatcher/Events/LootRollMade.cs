namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ rolled a \d+ on .+\.$""",
"""Brynna rolled a 87 on Drake Fang.""")]
public record LootRollMade(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
