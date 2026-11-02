namespace EverQuestLogWatcher;

[LogLinePattern(
"""^This land is saturated with unstable magic, (?<Bonus>.+)\.$""",
"""This land is saturated with unstable magic, which has drawn numerous mundane creatures here.""")]
public record AreaIsSaturatedWithUnstableMagic(Character Character, DateTime LocalTimestamp, string RawLogLine, string Bonus)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
