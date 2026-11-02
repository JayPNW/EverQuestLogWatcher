namespace EverQuestLogWatcher;

public abstract record CommandRejected(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
