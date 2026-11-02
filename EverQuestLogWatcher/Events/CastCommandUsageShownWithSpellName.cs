namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Usage: /cast <Spell Name>$""",
"""Usage: /cast <Spell Name>""")]
public record CastCommandUsageShownWithSpellName(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
