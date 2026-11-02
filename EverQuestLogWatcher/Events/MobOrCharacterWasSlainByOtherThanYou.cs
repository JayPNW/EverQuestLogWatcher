namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ was slain by .+!$""",
"""A Valorian Guardian was slain by Aldric!""")]
public record MobOrCharacterWasSlainByOtherThanYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
