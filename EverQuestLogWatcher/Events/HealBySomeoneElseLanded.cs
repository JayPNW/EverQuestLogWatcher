namespace EverQuestLogWatcher;

[LogLinePattern(
"""^(?!You ).+ healed .+(?: over time)? for \d+(?: \(\d+\))? hit points?(?: by .+)?\.(?: \([^)]+\))?$""",
"""Corwin healed Brynna over time for 1395 (2000) hit points by Pious Elixir.""",
"""Marek healed Nessa for 98024 hit points by Reckless Renewal. (Critical)""")]
public record HealBySomeoneElseLanded(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
