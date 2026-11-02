namespace EverQuestLogWatcher;

[LogLinePattern(
"""^(?!Your ).+'s (?:.+ )?spell fizzles!$""",
"""Brynna's Force of Piety spell fizzles!""",
"""Pell's spell fizzles!""")]
public record SomeoneElsesSpellFizzled(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
