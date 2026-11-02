namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You have gained an ability point!  You now have \d+ ability points?\.$""",
"""You have gained an ability point!  You now have 12 ability points.""")]
public record AbilityPointGained(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
