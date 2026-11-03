using System.Reflection;

namespace EverQuestLogWatcher.Tests;

public class EverQuestLogLineParserTests
{
    static readonly Character Rowan = new("Rowan", "fangbreaker");
    const string TimestampPrefix = "[Mon Sep 14 13:49:18 2026] ";

    static readonly SpellTextIndex SampleSpellTextIndex = new(
        [
            "1^Shards of Ice^x^",
            "2^Tashan's Lingering Cry^x^",
            "3^Quiet Mind^x^",
            "4^Quiet Mind Rk. II^x^",
            "5^Rune I^x^",
            "6^Generic Stagger^x^",
            "7^Unstun^x^",
            "8^Fade Emote^x^",
        ],
        [
            "#SPELLINDEX^CASTERMETXT^CASTEROTHERTXT^CASTEDMETXT^CASTEDOTHERTXT^SPELLGONE^",
            "1^^^You are slashed by shards of ice.^ is slashed by shards of ice.^^",
            "2^^^^ is slashed by shards of ice and frost.^^",
            "3^^^Your mind eases with thoughts of tranquility.^'s mind eases with thoughts of tranquility.^Your mind returns to normal.^",
            "4^^^Your mind eases with thoughts of tranquility.^'s mind eases with thoughts of tranquility.^Your mind returns to normal.^",
            "5^^^^^The shimmer of runes fades.^",
            "6^^^^ staggers.^^",
            "7^^^^^You are no longer stunned.^",
            "8^^^^ fades.^^",
        ]);

    static EverQuestLogEvent Parse(string message)
    {
        return new EverQuestLogLineParser(Rowan, SampleSpellTextIndex).Parse(TimestampPrefix + message);
    }

    [Fact]
    public Task EveryExampleInTheCatalogParsesToItsEvent()
    {
        var examples = typeof(EverQuestLogEvent).Assembly.GetTypes()
            .Where(type => type.IsSubclassOf(typeof(EverQuestLogEvent)) && !type.IsAbstract)
            .OrderBy(type => type.Name, StringComparer.Ordinal)
            .SelectMany(type => type.GetCustomAttributes<LogLinePatternAttribute>().SelectMany(pattern => pattern.ExampleMessages.Select(message => (type, message))));

        var parsedEventNames = new List<string>();
        foreach (var (exampleEventType, exampleMessage) in examples)
        {
            var logEvent = Parse(exampleMessage);
            Assert.IsType(exampleEventType, logEvent);
            parsedEventNames.Add(logEvent.GetType().Name);
        }

        return Verify(parsedEventNames);
    }

    [Fact]
    public Task EventSaysWhenAndWhoseLog()
    {
        var logEvent = Parse("You have entered The Plane of Tranquility.");

        return Verify(logEvent).Snapshot(
            """
            {
              ZoneName: The Plane of Tranquility,
              Character: {
                Name: Rowan,
                Server: fangbreaker
              },
              LocalTimestamp: DateTime_1,
              RawLogLine: [Mon Sep 14 13:49:18 2026] You have entered The Plane of Tranquility.
            }
            """);
    }

    [Fact]
    public void LineWithoutTimestampIsUnrecognized()
    {
        var logEvent = new EverQuestLogLineParser(Rowan).Parse("You have entered The Plane of Tranquility.");

        Assert.IsType<Unrecognized>(logEvent);
    }

    [Fact]
    public void TimestampWithSingleDigitDayIsRead()
    {
        var logEvent = new EverQuestLogLineParser(Rowan).Parse("[Fri Sep 4 08:01:02 2026] You appear.");

        Assert.Equal(new DateTime(2026, 9, 4, 8, 1, 2), logEvent.LocalTimestamp);
    }

    [Fact]
    public void WoreOffTextRaisesSpellEffectOnYouFaded()
    {
        var logEvent = Assert.IsType<SpellEffectOnYouFaded>(Parse("Your mind returns to normal."));

        Assert.Equal("Your mind returns to normal.", logEvent.FadeMessage);
        Assert.Equal(["Quiet Mind", "Quiet Mind Rk. II"], logEvent.PossibleSpellNames);
    }

    [Fact]
    public void ExactWoreOffTextWinsOverShortCastOnOtherText()
    {
        var logEvent = Assert.IsType<SpellEffectOnYouFaded>(Parse("The shimmer of runes fades."));

        Assert.Equal(["Rune I"], logEvent.PossibleSpellNames);
    }

    [Fact]
    public void EventPatternsWinOverWoreOffText()
    {
        Assert.IsType<YouAreNoLongerStunned>(Parse("You are no longer stunned."));
    }

    [Fact]
    public void CastOnYouTextRaisesSpellLandedOnYou()
    {
        var logEvent = Assert.IsType<SpellLandedOnYou>(Parse("You are slashed by shards of ice."));

        Assert.Equal(["Shards of Ice"], logEvent.PossibleSpellNames);
    }

    [Fact]
    public void CastOnOtherTextRaisesSpellLandedOnSomeoneElse()
    {
        var logEvent = Assert.IsType<SpellLandedOnSomeoneElse>(Parse("A Delve drake is slashed by shards of ice."));

        Assert.Equal("A Delve drake", logEvent.TargetName);
        Assert.Equal(["Shards of Ice"], logEvent.PossibleSpellNames);
    }

    [Fact]
    public void PossessiveCastOnOtherTextLeavesThePossessiveOutOfTheTargetName()
    {
        var logEvent = Assert.IsType<SpellLandedOnSomeoneElse>(Parse("Aldric's mind eases with thoughts of tranquility."));

        Assert.Equal("Aldric", logEvent.TargetName);
    }

    [Fact]
    public void LongestCastOnOtherTextWins()
    {
        var logEvent = Assert.IsType<SpellLandedOnSomeoneElse>(Parse("A Delve drake is slashed by shards of ice and frost."));

        Assert.Equal("A Delve drake", logEvent.TargetName);
        Assert.Equal(["Tashan's Lingering Cry"], logEvent.PossibleSpellNames);
    }

    [Fact]
    public void CastOnOtherTextWithNothingBeforeItIsUnrecognized()
    {
        Assert.IsType<Unrecognized>(Parse(" is slashed by shards of ice."));
    }

    [Fact]
    public void WithoutSpellFilesSpellTextIsUnrecognized()
    {
        var logEvent = new EverQuestLogLineParser(Rowan).Parse(TimestampPrefix + "A Delve drake is slashed by shards of ice.");

        Assert.IsType<Unrecognized>(logEvent);
    }

    [Fact]
    public void MissingSpellFilesGiveAnEmptyIndex()
    {
        var index = SpellTextIndex.LoadFromEverQuestInstallDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));

        Assert.Same(SpellTextIndex.Empty, index);
    }

    [Fact]
    public void DailyResetMessageRaisesDailyResetLogEvent()
    {
        Assert.IsType<DailyResetLogEvent>(Parse("Fonts of unstable magic are erupting and receding in response to some nameless power. The magic is cascading throughout Norrath and into the Planes beyond. Hunt for the lands that have been most recently saturated with this magic to reap their many and varied resources."));
    }

    [Fact]
    public void CampAbandonedMessageRaisesCampAbandonedLogEvent()
    {
        Assert.IsType<CampAbandonedLogEvent>(Parse("You abandon your preparations to camp."));
    }

    [Fact]
    public void SlainByPetCapturesOwnerName()
    {
        var logEvent = Assert.IsType<SlainByPet>(Parse("A Valorian Guardian was slain by Bob`s pet!"));

        Assert.Equal("Bob", logEvent.OwnerName);
    }

    [Fact]
    public void SlainByWarderCapturesOwnerName()
    {
        var logEvent = Assert.IsType<SlainByWarder>(Parse("A Valorian Guardian was slain by Bob`s warder!"));

        Assert.Equal("Bob", logEvent.OwnerName);
    }
}
