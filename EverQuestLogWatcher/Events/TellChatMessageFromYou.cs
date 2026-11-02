namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You told [^,]+, '.*'$""",
"""You told Kestrel, 'thanks'""")]
public record TellChatMessageFromYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
