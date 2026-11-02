namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You begin (?:casting|singing) .+\.$""",
"""You begin casting Howl of Tashan.""",
"""You begin singing Guardian Rhythms.""")]
public record YouBeganCasting(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
