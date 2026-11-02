namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Usage: /cast <Spell Gem Slot Number>$""",
"""Usage: /cast <Spell Gem Slot Number>""")]
public record CastCommandUsageShownWithSpellGemSlotNumber(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
