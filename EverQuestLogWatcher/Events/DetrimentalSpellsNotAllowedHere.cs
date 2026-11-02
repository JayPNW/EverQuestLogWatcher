namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You cannot cast detrimental spells here.""")]
public record DetrimentalSpellsNotAllowedHere(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
