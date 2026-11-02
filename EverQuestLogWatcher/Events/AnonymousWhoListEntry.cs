namespace EverQuestLogWatcher;

[LogLinePattern(
"""^\[ANONYMOUS\] \S+(?: <[^>]+>)? *$""",
"""[ANONYMOUS] Ulric <Example Guild One>""",
"""[ANONYMOUS] Vesna""")]
public record AnonymousWhoListEntry(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
