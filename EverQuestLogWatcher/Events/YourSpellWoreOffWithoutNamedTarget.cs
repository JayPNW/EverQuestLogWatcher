namespace EverQuestLogWatcher;

[LogLinePattern(
"""^Your .+ spell has worn off\.$""",
"""Your Mesmerize spell has worn off.""")]
public record YourSpellWoreOffWithoutNamedTarget(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
