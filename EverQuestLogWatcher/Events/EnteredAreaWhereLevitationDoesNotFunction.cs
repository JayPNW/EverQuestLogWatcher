namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You have entered an area where levitation effects do not function.""")]
public record EnteredAreaWhereLevitationDoesNotFunction(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
