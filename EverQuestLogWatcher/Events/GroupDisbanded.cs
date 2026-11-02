namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Your group has been disbanded.""")]
public record GroupDisbanded(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
