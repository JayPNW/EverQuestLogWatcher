namespace EverQuestLogWatcher;

[LogLinePattern(
"""^--(?:a|an|\d+) .+ was left on .+'s corpse\.--$""",
"""--a Frothing Drake Blood was left on a Delve drake's corpse.--""")]
public record ItemLeftOnCorpse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
