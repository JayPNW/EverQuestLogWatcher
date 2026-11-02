namespace EverQuestLogWatcher;

[LogLinePattern(
"""^There (?:are|is) \d+ players? in EverQuest\.$""",
"""There are 27 players in EverQuest.""")]
public record WhoListFinished(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
