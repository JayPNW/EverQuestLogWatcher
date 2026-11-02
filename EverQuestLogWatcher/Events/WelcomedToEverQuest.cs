namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Welcome to EverQuest!""")]
public record WelcomedToEverQuest(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
