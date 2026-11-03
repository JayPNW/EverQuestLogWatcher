namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You abandon your preparations to camp.""")]
public record CampAbandonedLogEvent(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
