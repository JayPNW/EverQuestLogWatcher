namespace EverQuestLogWatcher;

[LogLinePattern(
"""^--You have looted (?:a|an|\d+) .+(?: from .+'s corpse)?\.--$""",
"""--You have looted a Hero Parts from a Valorian Guardian's corpse.--""",
"""--You have looted a Spider Silk.--""")]
public record ItemLootedByYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
