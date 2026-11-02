namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Could not find memorized spell to cast.""")]
public record SpellToCastIsNotMemorized(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
