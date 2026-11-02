namespace EverQuestLogWatcher;

[LogLinePattern(
"""^(?!Your ).+'s .+ spell is interrupted\.$""",
"""Brynna's Cease spell is interrupted.""")]
public record SomeoneElsesSpellWasInterrupted(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
