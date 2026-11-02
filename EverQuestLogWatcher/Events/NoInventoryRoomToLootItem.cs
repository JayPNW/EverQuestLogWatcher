namespace EverQuestLogWatcher;

[LogLineLiteral(
"""You cannot loot this item no room in your inventory.""")]
public record NoInventoryRoomToLootItem(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : CommandRejected(Character, LocalTimestamp, RawLogLine);
