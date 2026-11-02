namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Players (?:in|on) EverQuest:$""",
"""Players in EverQuest:""")]
public record WhoListStarted(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
