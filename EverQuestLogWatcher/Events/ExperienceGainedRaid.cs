namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You gain raid experience(?: \(with a bonus\))?!!?(?: \(\d+(?:\.\d+)?%\))?$""",
"""You gain raid experience! (0.5%)""",
"""You gain raid experience (with a bonus)!""")]
public record ExperienceGainedRaid(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
