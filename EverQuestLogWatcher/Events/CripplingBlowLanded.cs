namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ lands a Crippling Blow!\(\d+\)$""",
"""Tamsin lands a Crippling Blow!(212)""")]
public record CripplingBlowLanded(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
