namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You are now A.F.K. (Away From Keyboard).""")]
public record AwayFromKeyboardStarted(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
