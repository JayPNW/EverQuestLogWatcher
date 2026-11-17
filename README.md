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

await foreach (var logEvent in watcher.WatchAsync(new EverQuestLogWatcherOptions {/*...*/}))
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
| `ReplayLinesAlreadyInLogWhenStarting` | When false (the default), logs found when watching starts are followed from their current end. When true, they are read from their beginning. Logs found later, such as when EverQuest starts after watching does, are always followed from their current end. |
| `PollingInterval`                     | How often to look for new clients, new log files and new lines.                                                                                                                                                                  |

## Checking that EverQuest is running and logging

The watcher only raises events while EverQuest is running with logging turned on. Use `FindRunningInstalls()` to check:

<!-- snippet: CheckRunningAndLogging -->
<a id='snippet-CheckRunningAndLogging'></a>
```cs
var installs = watcher.FindRunningInstalls();
if (installs.Count == 0)
{
    Console.WriteLine("EverQuest is not running.");
}

foreach (var install in installs.Where(i => !i.IsLoggingEnabled))
{
    Console.WriteLine($"Logging is off for {install.InstallDirectory}. Type `/log on` in game.");
}
```
<sup><a href='/EverQuestLogWatcher.Tests/ReadmeExample.cs#L24-L35' title='Snippet source file'>snippet source</a> | <a href='#snippet-CheckRunningAndLogging' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

`IsLoggingEnabled` is true when `eqclient.ini` contains `Log=1` or `Log=true`. It doesn't know about `/log on` typed in game.

## Spell parsing

EQ logs show spell landing and wore-off messages without naming the spell.
To work out which spell a message belongs to, the library reads `spells_us.txt` and `spells_us_str.txt` from the EverQuest install directory of the running client.

## Missing events

There are many different possible event messages in EQ. This library detects some but many are just listed as "Unrecognized".
If you are writing a tool that needs one of the Unknown events to be detected, open an Issue in this repo.

## Event catalog

See [docs/EventCatalog.md](docs/EventCatalog.md) for the full list of detected events and the messages that trigger them.
