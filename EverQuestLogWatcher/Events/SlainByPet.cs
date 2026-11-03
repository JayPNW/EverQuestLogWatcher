namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ was slain by (?<OwnerName>[^`]+)`s pet!$""",
"""A Valorian Guardian was slain by Bob`s pet!""")]
public record SlainByPet(Character Character, DateTime LocalTimestamp, string RawLogLine, string OwnerName)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
