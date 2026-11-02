namespace EverQuestLogWatcher;

[LogLinePattern(
"""^\[\d+ (?:[^()\]]+ \([^)]+\)|[^\]]+)\] \S+(?: \([^)]+\))?(?: <[^>]+>)?(?: ZONE: (?:.+ \([^)]+\)|\S+))? *$""",
"""[70 Bedazzler (Enchanter)] Rowan (Gnome) <Example Guild Two> ZONE: Torden, the Bastion of Thunder (bothunder)""",
"""[32 Warrior] Sorrel (Barbarian) <Example Guild Three> ZONE: greatdivide""")]
public record WhoListEntry(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
