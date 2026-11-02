namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ scores a critical hit! \(\d+\)$""",
"""Tamsin scores a critical hit! (88)""")]
public record CriticalMeleeHitScored(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
