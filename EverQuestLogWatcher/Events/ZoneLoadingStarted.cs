namespace EverQuestLogWatcher;

[LogLineLiteral(
"""LOADING, PLEASE WAIT...""")]
public record ZoneLoadingStarted(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
