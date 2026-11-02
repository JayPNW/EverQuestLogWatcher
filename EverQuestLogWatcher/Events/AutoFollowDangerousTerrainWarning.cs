namespace EverQuestLogWatcher;

[LogLineLiteral(
"""*WARNING*: Do NOT use around lava, water, cliffs, or other dangerous areas because you WILL fall into them. You have been warned.""")]
public record AutoFollowDangerousTerrainWarning(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
