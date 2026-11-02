namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You are not currently assigned to an adventure.""")]
public record NoAdventureAssigned(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
