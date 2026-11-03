namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ was slain by (?<OwnerName>[^`]+)`s warder!$""",
"""A Valorian Guardian was slain by Bob`s warder!""")]
public record SlainByWarder(Character Character, DateTime LocalTimestamp, string RawLogLine, string OwnerName)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
