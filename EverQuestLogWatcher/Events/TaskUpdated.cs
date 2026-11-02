namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Your task '.+' has been updated\.$""",
"""Your task 'Drake Hunting' has been updated.""")]
public record TaskUpdated(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
