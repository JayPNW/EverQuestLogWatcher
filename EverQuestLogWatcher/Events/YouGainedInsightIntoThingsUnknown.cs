namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You gain insight into things unknown.""")]
public record YouGainedInsightIntoThingsUnknown(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
