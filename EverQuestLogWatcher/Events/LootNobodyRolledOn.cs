namespace EverQuestLogWatcher;

[LogLinePattern(
"""^No one was interested in the \d+ item\(s\): .+\. These items can be randomed again or will be available to everyone after the corpse unlocks\.$""",
"""No one was interested in the 1 item(s): Chitin Blade. These items can be randomed again or will be available to everyone after the corpse unlocks.""")]
public record LootNobodyRolledOn(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
