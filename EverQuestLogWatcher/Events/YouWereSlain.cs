namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You have been slain by .+!$""",
"""You have been slain by a dragorn peon!""")]
public record YouWereSlain(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
