namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You are no longer A.F.K. (Away From Keyboard).""")]
public record AwayFromKeyboardEnded(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
