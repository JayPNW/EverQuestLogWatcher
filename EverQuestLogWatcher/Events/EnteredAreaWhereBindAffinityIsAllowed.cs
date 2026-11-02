namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You have entered an area where Bind Affinity is allowed.""")]
public record EnteredAreaWhereBindAffinityIsAllowed(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
