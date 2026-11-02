namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ won the (?:need|greed) roll on \d+ item\(s\): .+ with a roll of \d+\.$""",
"""Brynna won the need roll on 1 item(s): Drake Fang with a roll of 87.""")]
public record LootRollWon(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
