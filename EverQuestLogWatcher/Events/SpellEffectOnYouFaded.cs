namespace EverQuestLogWatcher;

[MatchedBySpellFileText("""The shimmer of runes fades.""")]
public record SpellEffectOnYouFaded(Character Character, DateTime LocalTimestamp, string RawLogLine, string FadeMessage, IReadOnlyList<string> PossibleSpellNames)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
