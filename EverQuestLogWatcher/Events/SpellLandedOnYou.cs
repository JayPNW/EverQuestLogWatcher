namespace EverQuestLogWatcher;

[MatchedBySpellFileText("""Your mind eases with thoughts of tranquility.""")]
public record SpellLandedOnYou(Character Character, DateTime LocalTimestamp, string RawLogLine, IReadOnlyList<string> PossibleSpellNames)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
