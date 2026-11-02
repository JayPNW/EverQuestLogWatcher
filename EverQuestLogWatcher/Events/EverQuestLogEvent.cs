namespace EverQuestLogWatcher;

public abstract record EverQuestLogEvent(Character Character, DateTime LocalTimestamp, string RawLogLine);
