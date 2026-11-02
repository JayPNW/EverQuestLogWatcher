namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You have left all channels""")]
public record LeftAllChatChannels(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
