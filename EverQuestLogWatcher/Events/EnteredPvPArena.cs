namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You have entered an Arena (PvP) area.""")]
public record EnteredPvPArena(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
