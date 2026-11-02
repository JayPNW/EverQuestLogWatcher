namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You healed .+ over time for \d+(?: \(\d+\))? hit points?(?: by .+)?\.(?: \([^)]+\))?$""",
"""You healed Quill over time for 1395 (2000) hit points by Pious Elixir.""")]
public record YourHealOvertimeLanded(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
