| Event | Example messages | Regex |
|---|---|---|
| `AbilityPointGained` | ` You have gained an ability point!  You now have 12 ability points. ` | ` ^You have gained an ability point!  You now have \d+ ability points?\.$ ` |
| `AbilityStillOnCooldown` | ` You can use the ability Entrap again in 2 minute(s) 14 seconds. ` | ` ^You can use the ability .+ again in (?:\d+ minute\(s\) )?\d+ seconds?\.$ ` |
| `AlternateAdvancementAbilityImproved` | ` You have improved Innate Spell Resistance 5 at a cost of 0 ability points. ` | ` ^You have improved .+ \d+ at a cost of \d+ ability points?\.$ ` |
| `AnonymousWhoListEntry` | ` [ANONYMOUS] Ulric <Example Guild One> `<br>` [ANONYMOUS] Vesna ` | ` ^\[ANONYMOUS\] \S+(?: <[^>]+>)? *$ ` |
| `AreaIsSaturatedWithUnstableMagic` | ` This land is saturated with unstable magic, which has drawn numerous mundane creatures here. ` | ` ^This land is saturated with unstable magic, (?<Bonus>.+)\.$ ` |
| `AuctionChatMessageFromSomeoneElse` | ` Elowen auctions, 'wts Seahorse Spine Bracelet' ` | ` ^[^,]+ auctions, '.*'$ ` |
| `AuctionChatMessageFromYou` | ` You auction, 'wtb bone chips' ` | ` ^You auction, '.*'$ ` |
| `AutoFollowStarted` | ` You will now auto-follow Aldric. ` | ` ^You will now auto-follow .+\.$ ` |
| `AutoFollowStopped` | ` You are no longer auto-following Aldric. ` | ` ^You are no longer auto-following .+\.$ ` |
| `CampingCountdownProgressed` | ` It will take you about 30 seconds to prepare your camp. `<br>` It will take about 25 more seconds to prepare your camp. ` | ` ^It will take (?:you )?about \d+ (?:more )?seconds to prepare your camp\.$ ` |
| `CastCommandUsageShownWithSpellGemSlotNumber` : `CommandRejected` | ` Usage: /cast <Spell Gem Slot Number> ` | ` ^Usage: /cast <Spell Gem Slot Number>$ ` |
| `CastCommandUsageShownWithSpellName` : `CommandRejected` | ` Usage: /cast <Spell Name> ` | ` ^Usage: /cast <Spell Name>$ ` |
| `ChatChannelsListed` | ` Channels: 1=General(264), 2=Enchanter(14), 3=Planes(129) ` | ` ^Channels: \d+=\w+\(\d+\)(?:, \d+=\w+\(\d+\))*$ ` |
| `CoinSplitReceived` | ` You receive 2 platinum, 4 gold and 1 copper as your split (with a bonus). ` | ` ^You receive (?:(?:, \| and )?(?:\d+ platinum\|\d+ gold\|\d+ silver\|\d+ copper))+ as your split(?: \(with a bonus\))?\.$ ` |
| `CripplingBlowLanded` | ` Tamsin lands a Crippling Blow!(212) ` | ` ^.+ lands a Crippling Blow!\(\d+\)$ ` |
| `CriticalMeleeHitScored` | ` Tamsin scores a critical hit! (88) ` | ` ^.+ scores a critical hit! \(\d+\)$ ` |
| `DamageOverTimeBySomeoneElseTicked` | ` A Delve drake has taken 586 damage from Festering Darkness by Fenwick. ` | ` ^.+ (?:has\|have) taken \d+ damage from (?!your ).+ by .+\.$ ` |
| `DamageOverTimeByUnknownCasterTicked` | `` Garrick has taken 533 damage by Curse of Rhag`Zadune. `` | ` ^.+ (?:has\|have) taken \d+ damage by .+\.$ ` |
| `DamageShieldBetweenOthersHurtAttacker` | ` A Delve drake is burned by Brynna's flames for 45 points of non-melee damage. ` | ` ^(?!YOU ).+ is \w+ by .+'s \w+ for \d+ points? of non-melee damage[.!]$ ` |
| `DamageShieldHurtYou` | ` YOU are burned by a Delve spellbinder's flames for 30 points of non-melee damage! ` | ` ^YOU are \w+ by .+'s \w+ for \d+ points? of non-melee damage[.!]$ ` |
| `ExperienceGained` | ` You gain experience!! `<br>` You gain experience! (1.209%) ` | ` ^You gain experience!!?(?: \(\d+(?:\.\d+)?%\))?$ ` |
| `ExperienceGainedParty` | ` You gain party experience (with a bonus)! (1.25%) `<br>` You gain party experience!! ` | ` ^You gain party experience(?: \(with a bonus\))?!!?(?: \(\d+(?:\.\d+)?%\))?$ ` |
| `ExperienceGainedRaid` | ` You gain raid experience! (0.5%) `<br>` You gain raid experience (with a bonus)! ` | ` ^You gain raid experience(?: \(with a bonus\))?!!?(?: \(\d+(?:\.\d+)?%\))?$ ` |
| `ExtraMeleeAttacksGrantedByMasterWu` | ` The spirit of Master Wu fills you!  You gain 2 additional attack(s). ` | ` ^The spirit of Master Wu fills you!  You gain \d+ additional attack\(s\)\.$ ` |
| `FactionStandingAlreadyAtLimit` | ` Your faction standing with Kromrif could not possibly get any worse. ` | ` ^Your faction standing with .+ could not possibly get any (?:better\|worse)\.$ ` |
| `FactionStandingChanged` | ` Your faction standing with Tirranun has been adjusted by -5. ` | ` ^Your faction standing with .+ has been adjusted by -?\d+\.$ ` |
| `GroupChatMessageFromSomeoneElse` | ` Corwin tells the group, 'inc' ` | ` ^[^,]+ tells the group, '.*'$ ` |
| `GroupChatMessageFromYou` | ` You tell your party, 'pulling' ` | ` ^You tell your party, '.*'$ ` |
| `GroupInvitationReceivedByYou` | ` Brynna invites you to join a group. ` | ` ^.+ invites you to join a group\.$ ` |
| `GroupInvitationSentByYou` | ` You invite Aldric to join your group. ` | ` ^You invite .+ to join your group\.$ ` |
| `GuildChatMessageFromSomeoneElse` | ` Dara tells the guild, 'grats' ` | ` ^[^,]+ tells the guild, '.*'$ ` |
| `GuildChatMessageFromYou` | ` You say to your guild, 'brb' ` | ` ^You say to your guild, '.*'$ ` |
| `HealBySomeoneElseLanded` | ` Corwin healed Brynna over time for 1395 (2000) hit points by Pious Elixir. `<br>` Marek healed Nessa for 98024 hit points by Reckless Renewal. (Critical) ` | ` ^(?!You ).+ healed .+(?: over time)? for \d+(?: \(\d+\))? hit points?(?: by .+)?\.(?: \([^)]+\))?$ ` |
| `ItemCannotBeAddedToTradeskillDepot` | ` Stone of Marking cannot be added to your personal tradeskill depot because this item does not stack. ` | ` ^.+ cannot be added to your personal tradeskill depot because .+\.$ ` |
| `ItemLeftOnCorpse` | ` --a Frothing Drake Blood was left on a Delve drake's corpse.-- ` | ` ^--(?:a\|an\|\d+) .+ was left on .+'s corpse\.--$ ` |
| `ItemLootedBySomeoneElse` | ` --Brynna has looted 3 Drake Fang from a Delve drake's corpse.-- ` | ` ^--.+ has looted (?:a\|an\|\d+) .+ from .+'s corpse\.--$ ` |
| `ItemLootedByYou` | ` --You have looted a Hero Parts from a Valorian Guardian's corpse.-- `<br>` --You have looted a Spider Silk.-- ` | ` ^--You have looted (?:a\|an\|\d+) .+(?: from .+'s corpse)?\.--$ ` |
| `LootNobodyRolledOn` | ` No one was interested in the 1 item(s): Chitin Blade. These items can be randomed again or will be available to everyone after the corpse unlocks. ` | ` ^No one was interested in the \d+ item\(s\): .+\. These items can be randomed again or will be available to everyone after the corpse unlocks\.$ ` |
| `LootRollMade` | ` Brynna rolled a 87 on Drake Fang. ` | ` ^.+ rolled a \d+ on .+\.$ ` |
| `LootRollWon` | ` Brynna won the need roll on 1 item(s): Drake Fang with a roll of 87. ` | ` ^.+ won the (?:need\|greed) roll on \d+ item\(s\): .+ with a roll of \d+\.$ ` |
| `LootedFromCorpse` | ` You receive 2 platinum, 1 silver and 5 copper from the corpse. ` | ` ^You receive .* from the corpse\.$ ` |
| `MobConsidered` | ` A drachnid scowls at you, ready to attack -- he appears to be quite formidable. (Lvl: 68) `<br>` a burly gnoll scowls at you, ready to attack -- looks kind of risky, but you might win. ` | ` ^.+ (?:regards you as an ally\|looks upon you warmly\|kindly considers you\|judges you amiably\|regards you indifferently\|looks your way apprehensively\|glowers at you dubiously\|glares at you threateningly\|scowls at you, ready to attack) -- .+\.(?: \(Lvl: \d+\))?$ ` |
| `MobOrCharacterHasBeenSlainByOtherThanYou` | ` Aldric has been slain by a dragorn peon! ` | ` ^.+ has been slain by .+!$ ` |
| `MobOrCharacterWasSlainByOtherThanYou` | ` A Valorian Guardian was slain by Aldric! ` | ` ^.+ was slain by .+!$ ` |
| `MobSlainByYou` | ` You have slain a Valorian Guardian! ` | ` ^You have slain .+!$ ` |
| `NumberedChannelChatMessageFromSomeoneElse` | ` Jorund tells General:1, '58 Rog LFG' ` | ` ^[^,]+ tells \w+:\d+, '.*'$ ` |
| `NumberedChannelChatMessageFromYou` | ` You tell General1:1, 'lfg' ` | ` ^You tell \w+:\d+, '.*'$ ` |
| `OtherPetStartedAttacking` | ` Hester has captured a dragorn peon's attention! ` | ` ^.+ has captured .+'s attention!$ ` |
| `OutOfCharacterChatMessageFromSomeoneElse` | ` Ilsa says out of character, 'one of the monkle shackles' ` | ` ^[^,]+ says out of character, '.*'$ ` |
| `OutOfCharacterChatMessageFromYou` | ` You say out of character, 'lfg' ` | ` ^You say out of character, '.*'$ ` |
| `RaidChatMessageFromSomeoneElse` | ` Corwin tells the raid, 'go' ` | ` ^[^,]+ tells the raid, '.*'$ ` |
| `RaidChatMessageFromYou` | ` You tell your raid, 'ready' ` | ` ^You tell your raid, '.*'$ ` |
| `SayChatMessageFromSomeoneElse` | ` A Valorian Guardian says, 'Death comes to us all.' `<br>` Guard Doolin says 'You're not welcome in Freeport.' ` | ` ^[^,]+ says,? '.*'$ ` |
| `SayChatMessageFromYou` | ` You say, 'hail' ` | ` ^You say, '.*'$ ` |
| `ShoutChatMessageFromSomeoneElse` | ` Elowen shouts, 'train to zone' ` | ` ^[^,]+ shouts, '.*'$ ` |
| `ShoutChatMessageFromYou` | ` You shout, 'help' ` | ` ^You shout, '.*'$ ` |
| `SkillImproved` | ` You have become better at Divination! (162) ` | ` ^You have become better at .+! \(\d+\)$ ` |
| `SlainByPet` | `` A Valorian Guardian was slain by Bob`s pet! `` | `` ^.+ was slain by (?<OwnerName>[^`]+)`s pet!$ `` |
| `SlainByWarder` | `` A Valorian Guardian was slain by Bob`s warder! `` | `` ^.+ was slain by (?<OwnerName>[^`]+)`s warder!$ `` |
| `SomeoneElseBecameGroupLeader` | ` Aldric is now the leader of your group. ` | ` ^.+ is now the leader of your group\.$ ` |
| `SomeoneElseBeganCasting` | ` Brynna begins casting Cease. `<br>` Orin begins singing Guardian Rhythms. ` | ` ^.+ begins (?:casting\|singing) .+\.$ ` |
| `SomeoneElseBeganCastingUnnamedSpell` | ` Brother Jentry begins to cast a spell. ` | ` ^.+ begins to cast a spell\.$ ` |
| `SomeoneElseJoinedGroup` | ` Aldric has joined the group. ` | ` ^.+ has joined the group\.$ ` |
| `SomeoneElseLeftGroup` | ` Dara has left the group. ` | ` ^.+ has left the group\.$ ` |
| `SomeoneElseSummonedMountOrItem` | ` Aldric summons an argent whirligig flyer. ` | ` ^.+ summons (?:a\|an) .+\.$ ` |
| `SomeoneElsesSpellFizzled` | ` Brynna's Force of Piety spell fizzles! `<br>` Pell's spell fizzles! ` | ` ^(?!Your ).+'s (?:.+ )?spell fizzles!$ ` |
| `SomeoneElsesSpellWasInterrupted` | ` Brynna's Cease spell is interrupted. ` | ` ^(?!Your ).+'s .+ spell is interrupted\.$ ` |
| `SpellDamageDealtBySomeoneElse` | ` Lyra hit a Delve drake for 1305 points of cold damage by Water Elemental Strike IV. ` | ` ^(?!You ).+ hit .+ for \d+ points? of \w+ damage by .+\.$ ` |
| `SpellForgotten` | ` You forget Gate. ` | ` ^You forget .+\.$ ` |
| `SpellMemorizationBegan` | ` Beginning to memorize Bind Affinity... ` | ` ^Beginning to memorize .+\.\.\.$ ` |
| `SpellMemorizationFinished` | ` You have finished memorizing Bind Affinity. ` | ` ^You have finished memorizing .+\.$ ` |
| `SpellOnlyWorksOnCertainTargets` : `CommandRejected` | ` This spell only works on constructs or elementals. ` | ` ^This spell only works on .+\.$ ` |
| `TaskUpdated` | ` Your task 'Drake Hunting' has been updated. ` | ` ^Your task '.+' has been updated\.$ ` |
| `TellChatMessageFromSomeoneElse` | ` Kestrel told you, 'omw' `<br>` Kestrel tells you, 'omw' ` | ` ^[^,]+ (?:tells\|told) you, '.*'$ ` |
| `TellChatMessageFromYou` | ` You told Kestrel, 'thanks' ` | ` ^You told [^,]+, '.*'$ ` |
| `WhoListEntry` | ` [70 Bedazzler (Enchanter)] Rowan (Gnome) <Example Guild Two> ZONE: Torden, the Bastion of Thunder (bothunder) `<br>` [32 Warrior] Sorrel (Barbarian) <Example Guild Three> ZONE: greatdivide ` | ` ^\[\d+ (?:[^()\]]+ \([^)]+\)\|[^\]]+)\] \S+(?: \([^)]+\))?(?: <[^>]+>)?(?: ZONE: (?:.+ \([^)]+\)\|\S+))? *$ ` |
| `WhoListFinished` | ` There are 27 players in EverQuest. ` | ` ^There (?:are\|is) \d+ players? in EverQuest\.$ ` |
| `WhoListSeparatorLine` | ` --------------------------- ` | ` ^-+$ ` |
| `WhoListStarted` | ` Players in EverQuest: ` | ` ^Players (?:in\|on) EverQuest:$ ` |
| `YouBeganCasting` | ` You begin casting Howl of Tashan. `<br>` You begin singing Guardian Rhythms. ` | ` ^You begin (?:casting\|singing) .+\.$ ` |
| `YouGainedRune` | ` You gain a rune for 250 points of absorption. ` | ` ^You gain a rune for \d+ points? of absorption\.$ ` |
| `YouHurtYourself` | ` You hurt yourself for 12 points. ` | ` ^You hurt yourself for \d+ points?\.$ ` |
| `YouSummonedMountOrItem` | ` You summon an argent whirligig flyer. ` | ` ^You summon (?:a\|an) .+\.$ ` |
| `YouWereSlain` | ` You have been slain by a dragorn peon! ` | ` ^You have been slain by .+!$ ` |
| `YourHealLanded` | ` You healed Quill for 60 (399) hit points by Greater Healing. ` | ` ^You healed (?!.+ over time for ).+ for \d+(?: \(\d+\))? hit points?(?: by .+)?\.(?: \([^)]+\))?$ ` |
| `YourHealOvertimeLanded` | ` You healed Quill over time for 1395 (2000) hit points by Pious Elixir. ` | ` ^You healed .+ over time for \d+(?: \(\d+\))? hit points?(?: by .+)?\.(?: \([^)]+\))?$ ` |
| `YourPetStartedAttacking` | ` Captured a dragorn peon's attention, Master! ` | ` ^Captured .+'s attention, Master!$ ` |
| `YourSpellDamageDealt` | ` You hit a dar ghoul knight for 123 points of magic damage by Smiting Strike. ` | ` ^You hit .+ for \d+ points? of \w+ damage by .+\.$ ` |
| `YourSpellWasInterrupted` | ` Your spell is interrupted. `<br>` Your Koadic's Endless Intellect spell is interrupted. ` | ` ^Your (?:.+ )?spell is interrupted\.$ ` |
| `YourSpellWoreOffTarget` | ` Your Howl of Tashan spell has worn off of a Valorian Guardian. ` | ` ^Your .+ spell has worn off of .+\.$ ` |
| `YourSpellWoreOffWithoutNamedTarget` | ` Your Mesmerize spell has worn off. ` | ` ^Your .+ spell has worn off\.$ ` |
| `ZoneEntered` | ` You have entered The Plane of Tranquility. ` | ` ^You have entered (?<ZoneName>.+)\.$ ` |
