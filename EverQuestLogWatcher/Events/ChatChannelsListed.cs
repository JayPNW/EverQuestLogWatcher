namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Channels: \d+=\w+\(\d+\)(?:, \d+=\w+\(\d+\))*$""",
"""Channels: 1=General(264), 2=Enchanter(14), 3=Planes(129)""")]
public record ChatChannelsListed(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
