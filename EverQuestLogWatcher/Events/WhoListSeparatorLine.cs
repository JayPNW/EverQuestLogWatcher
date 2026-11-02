namespace EverQuestLogWatcher;

[LogLinePattern(
"""^-+$""",
"""---------------------------""")]
public record WhoListSeparatorLine(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
