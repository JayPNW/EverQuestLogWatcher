namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You have finished memorizing .+\.$""",
"""You have finished memorizing Bind Affinity.""")]
public record SpellMemorizationFinished(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
