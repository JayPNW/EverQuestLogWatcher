# How spell parsing works

Internal notes for contributors.
For the user-facing behavior, see the README.

## Why spells are special

Most events are recognized by a `[LogLinePattern]` regex on the event record.
Spell messages can't be written that way.
A spell landing on you is just its flavor text, such as `Your mind eases with thoughts of tranquility.`, with no spell name in the line.
The only source of truth is the game's own spell files.

## Inputs

`SpellTextIndex` is built from two files in the EverQuest install directory.

1. `spells_us.txt` maps a spell index to a spell name.
1. `spells_us_str.txt` maps the same index to the texts the game shows: cast-on-you, cast-on-other and wore-off.

Both are `^`-delimited and read as Latin-1.
Use the `fetch-eq-spell-files` skill to download them.
If either file is missing or unreadable, `SpellTextIndex.Empty` is used and spell events are simply never raised.

## The index

For each spell, the index adds the spell name to three dictionaries keyed by exact text.

1. Wore-off text.
1. Cast-on-you text.
1. Cast-on-other text, only if it is at least `ShortestCastOnOtherTextTrusted` characters long.

Many spells share one text, so each value is a list of names.
Events therefore carry `PossibleSpellNames`, not a single name.

## Matching a line

Within `EventFromSpellText`, the checks run in this order:

1. Whole message equals a wore-off text: `SpellEffectOnYouFaded`.
1. Whole message equals a cast-on-you text: `SpellLandedOnYou`.
1. Message ends with a cast-on-other text: `SpellLandedOnSomeoneElse`.

## Cast-on-other texts

These texts begin with a blank where the target goes, as in ` has an unusual shimmer.`, so the log line is the target name followed by the text.
`LongestCastOnOtherTextEnding` tries each position in the message that follows a space or an apostrophe, starting from the left.
The first suffix found in the dictionary is the longest, and everything before it is the target name.
At least one character must precede the text, so the target name is never empty.

Short texts such as ` is hit.` would match unrelated lines, so texts shorter than 14 characters are left out of the index.
That means some real spell landings go unrecognized.
This is deliberate: a wrong event is worse than none.

## Adding or changing spell events

Spell-file events carry `[MatchedBySpellFileText("example message")]` instead of `[LogLinePattern]`.
The example is used by tests and by the generated event catalog.
The `add-log-event` skill covers the rest.
To check the behavior on real logs, run the `parse-eq-log` skill with `--spells`.
