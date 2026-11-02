namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Your faction standing with .+ could not possibly get any (?:better|worse)\.$""",
"""Your faction standing with Kromrif could not possibly get any worse.""")]
public record FactionStandingAlreadyAtLimit(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
