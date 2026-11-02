namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Captured .+'s attention, Master!$""",
"""Captured a dragorn peon's attention, Master!""")]
public record YourPetStartedAttacking(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
