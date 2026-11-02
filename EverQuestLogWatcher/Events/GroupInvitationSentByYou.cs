namespace EverQuestLogWatcher;

[LogLinePattern(
"""^You invite .+ to join your group\.$""",
"""You invite Aldric to join your group.""")]
public record GroupInvitationSentByYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
