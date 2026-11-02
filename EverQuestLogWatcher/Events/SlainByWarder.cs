namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ was slain by [^`]+`s warder!$""",
"""A Valorian Guardian was slain by Bob`s warder!""")]
public record SlainByWarder(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
