namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You receive alternate currency.""")]
public record UnnamedAlternateCurrencyReceived(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
