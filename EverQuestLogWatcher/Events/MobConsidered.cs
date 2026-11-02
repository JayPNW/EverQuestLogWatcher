namespace EverQuestLogWatcher;

[LogLinePattern(
"""^.+ (?:regards you as an ally|looks upon you warmly|kindly considers you|judges you amiably|regards you indifferently|looks your way apprehensively|glowers at you dubiously|glares at you threateningly|scowls at you, ready to attack) -- .+\.(?: \(Lvl: \d+\))?$""",
"""A drachnid scowls at you, ready to attack -- he appears to be quite formidable. (Lvl: 68)""",
"""a burly gnoll scowls at you, ready to attack -- looks kind of risky, but you might win.""")]
public record MobConsidered(Character Character, DateTime LocalTimestamp, string RawLogLine)
    : EverQuestLogEvent(Character, LocalTimestamp, RawLogLine);
