namespace EverQuestLogWatcher;

[LogLinePattern(
"""^[^,]+ says,? '.*'$""",
"""A Valorian Guardian says, 'Death comes to us all.'""",
"""Guard Doolin says 'You're not welcome in Freeport.'""")]
public record SayChatMessageFromSomeoneElse(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
