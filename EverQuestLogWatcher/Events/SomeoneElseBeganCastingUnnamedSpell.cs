namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ begins to cast a spell\.$""",
"""Brother Jentry begins to cast a spell.""")]
public record SomeoneElseBeganCastingUnnamedSpell(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
