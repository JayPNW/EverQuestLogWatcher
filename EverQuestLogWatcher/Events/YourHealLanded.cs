namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You healed (?!.+ over time for ).+ for \d+(?: \(\d+\))? hit points?(?: by .+)?\.(?: \([^)]+\))?$""",
"""You healed Quill for 60 (399) hit points by Greater Healing.""")]
public record YourHealLanded(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
