namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ summons (?:a|an) .+\.$""",
"""Aldric summons an argent whirligig flyer.""")]
public record SomeoneElseSummonedMountOrItem(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
