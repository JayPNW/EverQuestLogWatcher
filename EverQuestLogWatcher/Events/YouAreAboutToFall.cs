namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You feel as if you are about to fall.""")]
public record YouAreAboutToFall(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
