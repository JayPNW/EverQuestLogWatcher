namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You summon (?:a|an) .+\.$""",
"""You summon an argent whirligig flyer.""")]
public record YouSummonedMountOrItem(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
