namespace EverQuestLogWatcher;

[LogLineLiteral(
"""Your account has one or more rewards waiting to be claimed.  You may use the Claim Window to view and claim your rewards.  Please remember that each reward can only be claimed by a single character on a single server on this account.""")]
public record UnclaimedRewardsWaiting(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
