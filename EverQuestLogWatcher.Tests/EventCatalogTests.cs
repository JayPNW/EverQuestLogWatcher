using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace EverQuestLogWatcher.Tests;

public class EventCatalogTests
{
    static readonly Type[] ConcreteEventTypes = [.. typeof(EverQuestLogEvent).Assembly.GetTypes()
        .Where(type => type.IsSubclassOf(typeof(EverQuestLogEvent)) && !type.IsAbstract)
        .OrderBy(type => type.Name, StringComparer.Ordinal)];

    static readonly (Type EventType, LogLinePatternAttribute Pattern)[] AllPatterns = [.. ConcreteEventTypes.SelectMany(type => type.GetCustomAttributes<LogLinePatternAttribute>().Select(pattern => (type, pattern)))];

    static readonly (Type EventType, MatchedBySpellFileTextAttribute SpellFileMatch)[] AllSpellFileMatches = [.. ConcreteEventTypes.SelectMany(type => type.GetCustomAttributes<MatchedBySpellFileTextAttribute>().Select(match => (type, match)))];

    [Fact]
    public Task CatalogOfEventsWithLiteralMessages()
    {
        var markdown = new StringBuilder();
        markdown.AppendLine("| Event | Message |");
        markdown.AppendLine("|---|---|");
        foreach (var eventType in ConcreteEventTypes)
        {
            if (eventType.GetCustomAttribute<LogLinePatternAttribute>() is LogLineLiteralAttribute literal)
            {
                markdown.AppendLine($"| {NameWithAnyIntermediateBaseType(eventType)} | {AsMarkdownCode(literal.ExampleMessages.Single())} |");
            }
        }

        return Verify(markdown.ToString(), extension: "include.md").UseFileName("EventLiteralCatalog");
    }

    [Fact]
    public Task CatalogOfEventsWithExamplesAndPatterns()
    {
        var markdown = new StringBuilder();
        markdown.AppendLine("| Event | Example messages | Regex or spell file match |");
        markdown.AppendLine("|---|---|---|");
        foreach (var eventType in ConcreteEventTypes)
        {
            var eventNameWithAnyIntermediateBaseType = NameWithAnyIntermediateBaseType(eventType);
            var pattern = eventType.GetCustomAttribute<LogLinePatternAttribute>();
            if (pattern is not null and not LogLineLiteralAttribute)
            {
                AppendRow(markdown, eventNameWithAnyIntermediateBaseType, pattern.ExampleMessages, AsMarkdownCode(pattern.RegexMatchingWholeMessage));
            }

            foreach (var spellFileMatch in eventType.GetCustomAttributes<MatchedBySpellFileTextAttribute>())
            {
                AppendRow(markdown, eventNameWithAnyIntermediateBaseType, [spellFileMatch.ExampleMessage], "`spells_us_str.txt`");
            }
        }

        return Verify(markdown.ToString(), extension: "include.md").UseFileName("EventPatternCatalog");
    }

    [Fact]
    public void EveryEventExceptUnrecognizedSaysHowItIsMatched()
    {
        var eventsWithNoWayToMatch = ConcreteEventTypes
            .Where(type => type != typeof(Unrecognized))
            .Where(type => !type.GetCustomAttributes<LogLinePatternAttribute>().Any())
            .Where(type => !type.GetCustomAttributes<MatchedBySpellFileTextAttribute>().Any())
            .Select(type => type.Name);

        Assert.Empty(eventsWithNoWayToMatch);
    }

    [Fact]
    public void EventRulesListsEveryEventWithAPatternExactlyOnce()
    {
        var eventsWithAPattern = AllPatterns.Select(entry => entry.EventType);

        var missingFromList = eventsWithAPattern.Except(EventRules.InOrderTried).Select(type => type.Name);
        var listedMoreThanOnce = EventRules.InOrderTried.GroupBy(type => type).Where(group => group.Count() > 1).Select(group => group.Key.Name);
        var listedWithoutAPattern = EventRules.InOrderTried.Except(eventsWithAPattern).Select(type => type.Name);

        Assert.Empty(missingFromList);
        Assert.Empty(listedMoreThanOnce);
        Assert.Empty(listedWithoutAPattern);
    }

    [Fact]
    public void EachExampleIsClaimedByTheFirstRuleThatMatchesItAndThatIsTheEventItIsAnExampleOf()
    {
        var examples = AllPatterns.SelectMany(entry => entry.Pattern.ExampleMessages.Select(exampleMessage => (entry.EventType, exampleMessage)))
            .Concat(AllSpellFileMatches.Select(entry => (entry.EventType, entry.SpellFileMatch.ExampleMessage)));

        var problems = new List<string>();
        foreach (var (exampleEventType, exampleMessage) in examples)
        {
            var firstMatchingEventType = EventRules.InOrderTried
                .FirstOrDefault(eventType => Regex.IsMatch(exampleMessage, eventType.GetCustomAttribute<LogLinePatternAttribute>()!.RegexMatchingWholeMessage));

            var exampleIsMatchedBySpellFile = AllSpellFileMatches.Any(entry => entry.SpellFileMatch.ExampleMessage == exampleMessage);
            var expectedEventType = exampleIsMatchedBySpellFile ? null : exampleEventType;

            if (firstMatchingEventType != expectedEventType)
            {
                problems.Add($"{exampleEventType.Name} example \"{exampleMessage}\" was claimed by: {firstMatchingEventType?.Name ?? "no rule"}");
            }
        }

        Assert.Empty(problems);
    }

    static string NameWithAnyIntermediateBaseType(Type eventType)
    {
        if (eventType.BaseType == typeof(EverQuestLogEvent))
        {
            return $"`{eventType.Name}`";
        }

        return $"`{eventType.Name}` : `{eventType.BaseType!.Name}`";
    }

    static void AppendRow(StringBuilder markdown, string eventName, IEnumerable<string> exampleMessages, string matchDescription)
    {
        var examplesOnSeparateLines = string.Join("<br>", exampleMessages.Select(AsMarkdownCode));
        markdown.AppendLine($"| {eventName} | {examplesOnSeparateLines} | {matchDescription} |");
    }

    static string AsMarkdownCode(string text)
    {
        var longestBacktickRun = Regex.Matches(text, "`+").Select(match => match.Length).DefaultIfEmpty(0).Max();
        var fence = new string('`', longestBacktickRun + 1);
        var escapedForTableCell = text.Replace("|", "\\|");
        return $"{fence} {escapedForTableCell} {fence}";
    }
}
