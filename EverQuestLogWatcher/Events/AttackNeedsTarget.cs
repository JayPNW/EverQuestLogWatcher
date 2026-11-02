namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You must first click on the being you wish to attack!""")]
public record AttackNeedsTarget(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
