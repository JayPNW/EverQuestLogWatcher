namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Your .+ spell has worn off of .+\.$""",
"""Your Howl of Tashan spell has worn off of a Valorian Guardian.""")]
public record YourSpellWoreOffTarget(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
