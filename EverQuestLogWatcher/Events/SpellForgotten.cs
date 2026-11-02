namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You forget .+\.$""",
"""You forget Gate.""")]
public record SpellForgotten(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
