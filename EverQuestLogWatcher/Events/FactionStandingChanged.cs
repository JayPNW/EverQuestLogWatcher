namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Your faction standing with .+ has been adjusted by -?\d+\.$""",
"""Your faction standing with Tirranun has been adjusted by -5.""")]
public record FactionStandingChanged(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
