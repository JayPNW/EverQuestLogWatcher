namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You gain a rune for \d+ points? of absorption\.$""",
"""You gain a rune for 250 points of absorption.""")]
public record YouGainedRune(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
