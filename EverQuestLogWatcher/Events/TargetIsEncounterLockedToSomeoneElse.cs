namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Your attack failed because your target is Encounter Locked to someone else.""")]
public record TargetIsEncounterLockedToSomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
