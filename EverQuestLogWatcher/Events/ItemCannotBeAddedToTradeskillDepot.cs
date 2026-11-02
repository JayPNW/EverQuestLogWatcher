namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ cannot be added to your personal tradeskill depot because .+\.$""",
"""Stone of Marking cannot be added to your personal tradeskill depot because this item does not stack.""")]
public record ItemCannotBeAddedToTradeskillDepot(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
