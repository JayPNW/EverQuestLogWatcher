namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ has been slain by .+!$""",
"""Aldric has been slain by a dragorn peon!""")]
public record MobOrCharacterHasBeenSlainByOtherThanYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
