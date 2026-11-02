namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ invites you to join a group\.$""",
"""Brynna invites you to join a group.""")]
public record GroupInvitationReceivedByYou(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
