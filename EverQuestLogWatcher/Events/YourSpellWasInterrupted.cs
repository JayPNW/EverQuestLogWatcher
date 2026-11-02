namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Your (?:.+ )?spell is interrupted\.$""",
"""Your spell is interrupted.""",
"""Your Koadic's Endless Intellect spell is interrupted.""")]
public record YourSpellWasInterrupted(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
