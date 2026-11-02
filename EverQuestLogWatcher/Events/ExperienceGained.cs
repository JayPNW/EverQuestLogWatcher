namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You gain experience!!?(?: \(\d+(?:\.\d+)?%\))?$""",
"""You gain experience!!""",
"""You gain experience! (1.209%)""")]
public record ExperienceGained(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
