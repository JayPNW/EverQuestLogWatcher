namespace EverQuestLogWatcher;

[LogLinePattern(
"""^This spell only works on .+\.$""",
"""This spell only works on constructs or elementals.""")]
public record SpellOnlyWorksOnCertainTargets(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
