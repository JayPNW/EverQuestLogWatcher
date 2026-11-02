namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You can use the ability .+ again in (?:\d+ minute\(s\) )?\d+ seconds?\.$""",
"""You can use the ability Entrap again in 2 minute(s) 14 seconds.""")]
public record AbilityStillOnCooldown(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
