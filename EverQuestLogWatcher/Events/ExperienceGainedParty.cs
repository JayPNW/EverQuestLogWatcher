namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You gain party experience(?: \(with a bonus\))?!!?(?: \(\d+(?:\.\d+)?%\))?$""",
"""You gain party experience (with a bonus)! (1.25%)""",
"""You gain party experience!!""")]
public record ExperienceGainedParty(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
