namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Beginning to memorize .+\.\.\.$""",
"""Beginning to memorize Bind Affinity...""")]
public record SpellMemorizationBegan(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
