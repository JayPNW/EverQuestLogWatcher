namespace EverQuestLogWatcher;

[MatchedBySpellFileText("""A Delve drake is slashed by shards of ice.""")]
public record SpellLandedOnSomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine, string TargetName, IReadOnlyList<string> PossibleSpellNames)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
