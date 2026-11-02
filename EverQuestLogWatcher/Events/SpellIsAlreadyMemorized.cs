namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You cannot memorize a spell you already have memorized.""")]
public record SpellIsAlreadyMemorized(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
