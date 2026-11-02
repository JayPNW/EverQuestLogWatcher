namespace EverQuestLogWatcher;

[LogLinePattern(
"""^It will take (?:you )?about \d+ (?:more )?seconds to prepare your camp\.$""",
"""It will take you about 30 seconds to prepare your camp.""",
"""It will take about 25 more seconds to prepare your camp.""")]
public record CampingCountdownProgressed(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
