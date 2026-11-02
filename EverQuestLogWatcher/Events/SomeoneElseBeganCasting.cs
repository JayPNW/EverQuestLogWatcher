namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ begins (?:casting|singing) .+\.$""",
"""Brynna begins casting Cease.""",
"""Orin begins singing Guardian Rhythms.""")]
public record SomeoneElseBeganCasting(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
