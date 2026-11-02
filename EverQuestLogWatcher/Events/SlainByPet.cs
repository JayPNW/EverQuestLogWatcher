namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ was slain by [^`]+`s pet!$""",
"""A Valorian Guardian was slain by Bob`s pet!""")]
public record SlainByPet(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
