namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You cannot place containers in containers.""")]
public record CannotPlaceContainerInContainer(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
