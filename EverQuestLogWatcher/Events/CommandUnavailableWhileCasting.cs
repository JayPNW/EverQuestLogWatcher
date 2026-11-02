namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You can't use that command while casting...""")]
public record CommandUnavailableWhileCasting(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
