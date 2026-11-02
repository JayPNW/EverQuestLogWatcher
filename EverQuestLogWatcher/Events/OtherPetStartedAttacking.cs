namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ has captured .+'s attention!$""",
"""Hester has captured a dragorn peon's attention!""")]
public record OtherPetStartedAttacking(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
