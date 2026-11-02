namespace EverQuestLogWatcher;

[LogLineLiteral(
"""There are no open slots for the held item in your inventory.""")]
public record NoOpenInventorySlotForHeldItem(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
