namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You are no longer stunned.""")]
public record YouAreNoLongerStunned(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
