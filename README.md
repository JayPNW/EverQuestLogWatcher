# EverQuest Log Watcher

[![Build and test](https://github.com/JayPNW/EverQuestLogWatcher/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/JayPNW/EverQuestLogWatcher/actions/workflows/build-and-test.yml)
[![NuGet](https://img.shields.io/nuget/v/EverQuestLogWatcher.svg)](https://www.nuget.org/packages/EverQuestLogWatcher)

Library to monitor Everquest logs with basic event detection and handling.

Automatically identifies EQ log files from running `eqgame.exe` processes.

## Example

<!-- snippet: BasicExample -->
<a id='snippet-BasicExample'></a>
```cs
var watcher = new EverQuestLogWatcher();

await foreach (var logEvent in watcher.WatchAsync(new EverQuestLogWatcherOptions(), cancellationToken))
{
    if (logEvent is MobSlainByYou)
    {
        Console.WriteLine($"{logEvent.Character.Name} slew something: {logEvent.RawLogLine}");
    }
}
```
<sup><a href='/EverQuestLogWatcher.Tests/ReadmeExample.cs#L7-L17' title='Snippet source file'>snippet source</a> | <a href='#snippet-BasicExample' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

## Options

`EverQuestLogWatcherOptions` has these properties:

| Property                              | Description                                                                                                                                                                                                                      |
|---------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `ReplayLinesAlreadyInLogWhenStarting` | When false (the default), logs that exist when watching starts are followed from their current end. When true, they are read from their beginning. Log files created after watching starts are always read from their beginning. |
| `PollingInterval`                     | How often to look for new clients, new log files and new lines.                                                                                                                                                                  |

## Spell parsing

EQ logs show spell landing and wore-off messages without naming the spell.
To work out which spell a message belongs to, the library reads `spells_us.txt` and `spells_us_str.txt` from the EverQuest install directory of the running client.

## Missing events

There are many different possible event messages in EQ. This library detects some but many are just listed as "Unrecognized".
If you are writing a tool that needs one of the Unknown events to be detected, open an Issue in this repo.

## Event catalog

See [docs/EventCatalog.md](docs/EventCatalog.md) for the full list of detected events and the messages that trigger them.
