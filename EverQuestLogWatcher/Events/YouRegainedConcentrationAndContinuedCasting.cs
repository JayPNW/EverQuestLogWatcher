namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You regain your concentration and continue your casting.""")]
public record YouRegainedConcentrationAndContinuedCasting(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
