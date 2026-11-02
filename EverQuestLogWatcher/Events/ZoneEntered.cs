namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You have entered (?<ZoneName>.+)\.$""",
"""You have entered The Plane of Tranquility.""")]
public record ZoneEntered(Character Character, DateTime LocalTimestamp, string RawLogLine, string ZoneName)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
