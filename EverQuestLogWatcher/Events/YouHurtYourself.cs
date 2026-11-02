namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You hurt yourself for \d+ points?\.$""",
"""You hurt yourself for 12 points.""")]
public record YouHurtYourself(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
