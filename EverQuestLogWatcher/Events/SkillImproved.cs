namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You have become better at .+! \(\d+\)$""",
"""You have become better at Divination! (162)""")]
public record SkillImproved(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
