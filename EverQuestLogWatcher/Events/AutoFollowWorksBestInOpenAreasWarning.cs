namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Also, auto-follow works best in wide open areas with low lag.  Twisty areas, lag, and other factors may cause auto-follow to fail.""")]
public record AutoFollowWorksBestInOpenAreasWarning(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
