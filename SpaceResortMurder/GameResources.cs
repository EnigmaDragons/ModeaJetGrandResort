using SpaceResortMurder.ObjectivesX;
using System;
using System.Collections.Generic;
using SpaceResortMurder.Clues.CloningRoom;
using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.Deductions.CauseOfDeath;
using SpaceResortMurder.Deductions.MeleenasAccountValidity;
using SpaceResortMurder.Deductions.TheCulpritsMotive;
using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Deductions.VictimsIdentity;
using SpaceResortMurder.Deductions.ZaidsResortForBetaTesting;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.DilemmasX;
using SpaceResortMurder.DilemmasX.CoreDilemmas;
using SpaceResortMurder.ResolutionsX;
using SpaceResortMurder.State;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Clues.PoliceSpaceCraft;
using SpaceResortMurder.Deductions.ClonesDesign;
using SpaceResortMurder.Deductions.LaunchedTheShip;
using SpaceResortMurder.Deductions.TimeFrameForMurder;
using SpaceResortMurder.Pathways;
using MonoDragons.Core.Common;
using SpaceResortMurder.Dialogues;

namespace SpaceResortMurder
{
    public static class GameResources
    {
        public const string MainMenuSceneName = "Main Menu";
        public const string OptionsSceneName = "Options";
        public const string CreditsSceneName = "Credits";
        public const string DilemmasSceneName = "Dilemmas";
        public const string DialogueMemoriesScene = "Dialogue Memories";
        public const string ResolutionSceneName = "Resolution";
        public const string EndingSceneName = "Ending";

        public static void TestAllSymbols()
        {
            _scanInfo.Values.ForEach(s => TestSymbols(s));
            _clues.Values.ForEach(l => l.ForEach(s => TestSymbols(s)));
            _dilemmaOrDeductionText.Values.ForEach(s => TestSymbols(s));
            _objectiveNames.Values.ForEach(s => TestSymbols(s));
            _dialogues.Values.ForEach(d =>
            {
                TestSymbols(d.Opener);
                d.Elements.ForEach(s => TestSymbols(s.Line));
            });
            _resolutionQuestionsText.Values.ForEach(s => TestSymbols(s));
            _pathwayText.Values.ForEach(s => TestSymbols(s));
        }

        private static void TestSymbols(string stringWithSymbols)
        {
            if (stringWithSymbols.Where(c => c == '\\').Count() % 2 == 1)
                throw new FormatException("A resource uses the reserved character '\\' improperly, you are suppose to use them in pairs with the text evaluation symbol between them");
            var matches = Regex.Matches(stringWithSymbols, "\\\\([^\\\\]*)\\\\");
            foreach (Match match in matches)
                foreach (Capture capture in match.Captures)
                    // The first capture is the whole value not a value caught by the capture zone
                    if (!capture.Value.Contains("\\") && !_symbols.ContainsKey(capture.Value))
                        throw new NotImplementedException("A dilemma or deduction uses unimplemented symbol \"" + capture + "\"");
        }

        public static string GetScanInfo(string character)
        {
            return ReplaceSymbols(_scanInfo[character]);
        }

        public static string GetCharacterName(string character)
        {
            return ReplaceSymbols(_characterNames[character]);
        }

        public static string GetCharacterImage(string character, Expression expression)
        {
            return _characterExpressions[character + " " + expression];
        }

        public static string[] GetClueLines(string dialogOrClue)
        {
            return _clues[dialogOrClue].Select(ReplaceSymbols).ToArray();
        }

        public static string GetDilemmaOrDeductionText(string dilemmaOrDeduction)
        {
            return ReplaceSymbols(_dilemmaOrDeductionText[dilemmaOrDeduction]);
        }

        public static string GetObjectiveName(string objective)
        {
            return ReplaceSymbols(_objectiveNames[objective]);
        }

        public static DialogueSequence GetDialogueSequence(string dialog)
        {
            var sequence = _dialogues[dialog];
            return new DialogueSequence(ReplaceSymbols(sequence.Opener), sequence.Elements.Select(e =>
                new DialogueElement(e.IsCharacterTalking, e.Expression, ReplaceSymbols(e.Line))).ToArray());
        }

        public static string GetResolutionText(string resolution)
        {
            return ReplaceSymbols(_resolutionQuestionsText[resolution].ToCharArray());
        }

        public static string GetPathwayText(string pathway)
        {
            return ReplaceSymbols(_pathwayText[pathway]);
        }

        private static string ReplaceSymbols(string text)
        {
            return ReplaceSymbols(text.ToCharArray());
        }

        private static string ReplaceSymbols(char[] text)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < text.Length; i++)
                if (text[i] == '\\')
                {
                    var symbol = new StringBuilder();
                    for (i++; ; i++)
                        if (text[i] == '\\')
                        {
                            builder.Append(_symbols[symbol.ToString()]());
                            break;
                        }
                        else
                            symbol.Append(text[i]);
                }
                else
                    builder.Append(text[i]);
            return builder.ToString();
        }

        private static DictionaryWithDefault<string, string> _scanInfo = new DictionaryWithDefault<string, string>("This scan is not implemented")
        {
            { nameof(OfficerWarren),
                "Officer Warren, weighs 199 lb, no augments. \n" +
                "Once found guilty of petty theft at the age of 12. \n" +
                "Worked in the investigative department of Outer Planet Police for 17 years."}
        };

        private static DictionaryWithDefault<string, string> _characterNames = new DictionaryWithDefault<string, string>("Unnamed Character") {
            { nameof(OfficerWarren), "Warren, Officer" },
            { nameof(HackerMeleena), "Meleena Ka'lick, Corporate Freelancer" },
            { nameof(RaymondsClone), "Raymond, CEO of Human Perfect" },
            { nameof(ResearcherTravis), "Travis Falcon, Clone Researcher" },
            { nameof(ResortManagerZaid), "Zaid Ahuja, Resort Manager" },
        };

        private static DictionaryWithDefault<string, string> _characterExpressions = new DictionaryWithDefault<string, string>("characters/placeholder") {
            { nameof(OfficerWarren) + " " + Expression.Default, "characters/policeman" },
            { nameof(HackerMeleena) + " " + Expression.Default, "characters/hacker_corporate_spy" },
            { nameof(RaymondsClone) + " " + Expression.Default, "characters/random_npc_01" },
            { nameof(ResearcherTravis) + " " + Expression.Default, "characters/scientist_guy" },
            { nameof(ResortManagerZaid) + " " + Expression.Default, "Characters/resort_manager_colored" },
        };

        private static DictionaryWithDefault<string, string[]> _clues = new DictionaryWithDefault<string, string[]>(new string[] { "This clue has not been implemented" }) {
            #region Docking Bay
            { nameof(RaymondsShip), new string[] {
                "The ship is a Regal Glider an expensive personal craft.",
                "It is registered under the name of Raymond Soule.",
                "CEO of Human Perfect.",
                "There is a blast mark that comes from a T-71 Energy Blaster",
                "The door control has also been hacked to stay unlocked."
            } },
            { nameof(MeleenasShip), new string[] {
                "The ship is heavily modded, it is registered to a Meleena Ka'lick.",
                "She is a corporate freelancer",
                "Meleena must be pretty wealthy to own her own space craft."
            } },
            { nameof(PoliceCruiser), new string[] {
                "I don't think my ship relates to this murder."
            } },
            { nameof(GarbageAirlock), new string[] {
                "This is a garbage airlock that releases trash into space.",
                "This was clearly used today."
            } },
            #endregion

            #region Raymond's Ship Interior
            { nameof(RaymondsCorpse), new string[] {
                "Raymond died of asphyxiation.",
                "His body is ballooned up to twice his normal size, his tongue and eyes have boiled. Conclusion he spent time in space without a suit.",
                "He has bruising around his neck from someone trying to choke him with their arm prior to his exposure to space.",
                "He has 13 recent wide needle punctures.",
            } },
            { nameof(ShipsLogs), new string[] {
                "These logs might help me narrow down a time line.",
                $"The ship launched at 7:05 \nThe space hatch was opened at 7:10 \nThe space hatch closed at 7:20 \nThe ship landed at 7:25",
            } },
            { nameof(T71EnergyBlaster), new string[] {
                $"This is a T-71 Energy Blaster. It is registered to Raymond Soule.",
                "It possess a security feature that ensures the weilder's DNA matches Raymond Soule before you can fire.",
            } },
            { nameof(RaymondsPad), new string[] {
                "This is Raymond's personal pad.",
                "There is a list of resorts on here with Zaid's being one of them. A bunch of the resorts including Zaid's have been crossed out.",
                "This pad was last used at 7:50 to send a message approving Zaid's resort for beta-testing a new resort clone.",
            } },
            #endregion

            #region Meleena's Ship Interior
            { nameof(DataStick), new string[] {
                "This data stick might have something valuable on it, But it's encrypted.",
            } },
            { nameof(UnencryptedDataStick), new string[] {
                "The data stick contains Raymond's files about a recent cloning experiment gone wrong.",
                "The experiment made much more perfect clones signifigantly faster than any known method.",
                "It used needles to extract key matter for replication.",
                "The experiment turned deadly when all the clones tried to kill their look a likes",
                "It was a massacre. The researcher overseeing the project and paid for it with his life was Bernard Falcon.",
                "Raymond Soule covered up the massacre by staging a terroist attack that supposedly killed the people.",
            } },
            { nameof(SkeletonKey), new string[] {
                "These special skeleton keys are designed to overload unsecure door locks in a matter of nanoseconds.",
            } },
            { nameof(HackingRig), new string[] {
                "This is a hacker rig used by \"Data Raven\".",
                "\"Data Raven\" is responsible for numerous cases of information leaking about corporate corruption",
            } },
            #endregion

            #region Travis's Cloning Room
            { nameof(CloningChamber), new string[] {
                "This machine is where the person getting cloned lies.",
                "We used a new process, that makes more perfect clones, much faster than any known method.",
                "13 needles take sample matter from key places as the brain is scanned.",
                "It then rapidly replicates the matter to form the clone.",
                "This new process has not yet been approved for commercial use."
            } },
            #endregion

            #region Police Cruiser
            { nameof(Clock), new string[] {
                "The time reads 8:02 PM"
            } },
            #endregion
        };

        private static DictionaryWithDefault<string, DialogueSequence> _dialogues = new DictionaryWithDefault<string, DialogueSequence>(
            new DialogueSequence("This dialogue is not implemented", new DialogueElement(true, "This dialogue is not implemented"))) {
            #region Warren
            { nameof(WarrenIntroduction), new DialogueSequence(
                "Introduction.",
                new DialogueElement[] {
                    new DialogueElement(true, "Hello there \\Player\\. This is your fist time powering up so I better get you up to speed."),
                    new DialogueElement(true, "I'm Officer Warren, and you are an android detective."),
                    new DialogueElement(true, "You have the unique capability to be able to rapidly search up records of people and places and percieve things I can't."),
                    new DialogueElement(true, "Go ahead and look me up."),
                }
            ) },
            { nameof(PettyTheftAt12), new DialogueSequence(
                "Petty theft at 12.",
                new DialogueElement[] {
                    new DialogueElement(true, "You have got the hang of scanning, it's especially important when you are going toe to toe with someone with augments."),
                    new DialogueElement(true, "Directly before powering you on I got a call about the murder of Raymond Soule."),
                    new DialogueElement(true, "He is the CEO of the cloning company Human Perfect."),
                    new DialogueElement(true, "He arrived alive at ModeaJet Grand Resort at 7:00 AM this morning, but was found dead today in his ship."),
                    new DialogueElement(true, "Look around and tell me what can you infer from that."),
                }
            ) },
            { nameof(AnytimeUpTilNow), new DialogueSequence(
                "The murder take place anytime up until now.",
                new DialogueElement[] {
                    new DialogueElement(true, "Not quite with it yet I see."),
                    new DialogueElement(true, "No worries I said that he arrived at the resort at 7 AM alive."),
                }
            ) },
            { nameof(BetweenSevenAMToEightPM), new DialogueSequence(
                "The murder must have taken place between 7 AM and 8 PM.",
                new DialogueElement[] {
                    new DialogueElement(true, "Precisely! Looks like we're ready to get started. Let's start investigating Raymond's craft."),
                }
            ) },
            { nameof(WeHaveUntilMidnight), new DialogueSequence(
                "We have until midnight, it's best if we hurry.",
                new DialogueElement[] {
                    new DialogueElement(true, "What are you talking about?!"),
                    new DialogueElement(true, "Booting up for the first must be brutal."),
                }
            ) },

            { nameof(MeetingWarren), new DialogueSequence(
                "Incident details",
                new DialogueElement[] {
                    new DialogueElement(true, "Finally you made it!"),
                    new DialogueElement(true, "The victim is Raymond Soule, the CEO of the lead cloning company Human Perfect."),
                    new DialogueElement(true, "He was found dead inside his personal space craft at 8 PM."),
                    new DialogueElement(true, "The only people present in the space resort according to the resort manager were."),
                    new DialogueElement(true, "On your left Zaid the resort manager, he was the one that called in about the incident."),
                    new DialogueElement(true, "In the middle we have a lead reasearcher at Human Perfect Travis Falcon."),
                    new DialogueElement(true, "And on the right Meleena Ke'lick, her file says she is a corporate freelancer. But currently she is not employed by any company."),
                }
            ) },
            { nameof(NeedASearchOrder), new DialogueSequence(
                "I need a search order for Meleena's craft.",
                new DialogueElement[] {
                    new DialogueElement(true, "I am way ahead of you, I sent out a request as soon as I got here. Here is your search order."),
                }
            ) },
            #endregion

            #region Zaid
            { nameof(WhyWasRaymondHere), new DialogueSequence(
                "Why was Raymond visiting your resort?",
                new DialogueElement[] {
                    new DialogueElement(true, "Raymond was considering my resort for beta-testing Human Perfect's new clones specifically tailored for resorts."),
                }
            ) },
            { nameof(DidRaymondApproveYourResort), new DialogueSequence(
                "Did Raymond decide your resort was a good fit?",
                new DialogueElement[] {
                    new DialogueElement(true, "My resort is terrific, of course he did."),
                }
            ) },
            { nameof(DidYouReleaseTheGarbage), new DialogueSequence(
                "I noticed that the garbage airlock was recently used, was that you?",
                new DialogueElement[] {
                    new DialogueElement(true, "No I thought it was strange the garbage airlock was empty."),
                }
            ) },
            { nameof(WhySoFewPeopleAtTheResort), new DialogueSequence(
                "Your resort seems to be lacking in occupants?",
                new DialogueElement[] {
                    new DialogueElement(true, "It's been a rough year. Nothing I can't fix with a little effort."),
                }
            ) },
            { nameof(ZaidsAccount), new DialogueSequence(
                "Please tell me as detailed as you can remember what you can recall?",
                new DialogueElement[] {
                    new DialogueElement(true, "I was staying in my room when I got a notification that Raymond's ship was leaving."),
                    new DialogueElement(true, "I didn't find that odd until 20 minutes after it left, Raymond's ship was landing."),
                    new DialogueElement(true, "I headed over to the docking bay. That's where I saw Raymond's ship was open."),
                    new DialogueElement(true, "Upon coming over I saw Raymond's dead body and then immidiately called you."),
                }
            ) },
            { nameof(YouWereNotAcceptedForBetaTesting), new DialogueSequence(
                "You were not accepted for beta testing, I found a list of resorts and yours was crossed off?",
                new DialogueElement[] {
                    new DialogueElement(true, "But what about the message Raymond sent!"),
                    new DialogueElement(true, "Oh wait I shouldn't know about that..."),
                    new DialogueElement(true, "Alright truth is when I found Raymond's body I sent the message on his pad."),
                    new DialogueElement(true, "I needed this, to keep my place running, But I didn't kill him."),
                }
            ) },
            #endregion

            #region Meleena
            { nameof(MeleenasAccount), new DialogueSequence(
                "Please give my your account of today up until being brought by Officer Warren.",
                new DialogueElement[] {
                    new DialogueElement(true, "I take some kind of crime has been commited."), 
                    new DialogueElement(true, "I have been in my room relaxing and taking calls all day, I don't know anything."),
                }
            ) },
            { nameof(WhatIsACorporateFreelancerDoingHere), new DialogueSequence(
                "Why are you visiting this resort?",
                new DialogueElement[] {
                    new DialogueElement(true, "Between jobs I like to get some rest and relaxation."),
                }
            ) },
            { nameof(CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts), new DialogueSequence(
                "Corporate freelancers can't normally afford to own a space craft.",
                new DialogueElement[] {
                    new DialogueElement(true, "I'm a research specialist, tasked with gather invaluable market date."),
                    new DialogueElement(true, "You'd be surprised how well one gets paid when they are as good as me."),
                }
            ) },
            { nameof(SearchYourCraftForEvidence), new DialogueSequence(
                "We are going to need to check your craft for evidence.",
                new DialogueElement[] {
                    new DialogueElement(true, "You are going to need a search order for that!"),
                }
            ) },
            { nameof(ImOnlyInvestigatingTheMurder), new DialogueSequence(
                "I'm only investigating the murder, I don't care what other illegal activities you are up to.",
                new DialogueElement[] {
                    new DialogueElement(true, "You could probably get your search order anyway."),
                    new DialogueElement(true, "Alright I'm trusting you. I have unlocked my craft."),
                }
            ) },
            { nameof(HereIsTheSearchOrder), new DialogueSequence(
                "Here is the search order for your ship. You can open it or we can force entry.",
                new DialogueElement[] {
                    new DialogueElement(true, "You piece of junk, go on and destroy any shred of privacy us citizens have."),
                }
            ) },
            { nameof(YouBrokeIntoRaymondsShip), new DialogueSequence(
                "You broke into Raymond's craft with this skeleton key.",
                new DialogueElement[] {
                    new DialogueElement(true, "Alright I broke into his ship to find dirt on Human Perfect."),
                    new DialogueElement(true, "Just when I was going to leave, I felt the blast of something shoot the ship."),
                    new DialogueElement(true, "I quickly hid in a storage container and then quite some time later a male with a deep voice came in muttering to himself."),
                    new DialogueElement(true, "He took off with the ship. Shortly after he opened up the space hatch, and left."),
                    new DialogueElement(true, "I was curious so i peeked out of my hiding spot in time to see Raymond's corpse dropped into the ship."),
                    new DialogueElement(true, "Startled I quickly sealed my container again. Before the man returned into the ship."),
                    new DialogueElement(true, "He quickly landed the ship while cursing and took off out of the ship."),
                    new DialogueElement(true, "As soon as he left I booked it."),
                }
            ) },
            { nameof(CareToShowTheDirtYouCollected), new DialogueSequence(
                "This data stick shows signs of recent use, care to give me the encryption key?",
                new DialogueElement[] {
                    new DialogueElement(true, "There is some juicy pieces of dirt on Human Perfect and the shady Mr.Soule."),
                    new DialogueElement(true, "Here is your encryption key."),
                }
            ) },
            { nameof(YouNeedToUnencryptThisDataStick), new DialogueSequence(
                "The data stick on your craft has evidence, give me the encryption key.",
                new DialogueElement[] {
                    new DialogueElement(true, "Oh that's so sad, I lost the encryption key, and it would take the best AIs 290 years to crack. So good luck!"),
                }
            ) },
            { nameof(WontTurnYouInIfYouUnencryptThisDrive), new DialogueSequence(
                "I don't have to report your career choices, if you can give me the encryption for the drive.",
                new DialogueElement[] {
                    new DialogueElement(true, "Now you're talking, I hope I'm right about you being honest."),
                }
            ) },
            { nameof(ObstructionOfJusticeWillAddToYourPrisonTime), new DialogueSequence(
                "Obstruction of justice will only extend your prison time.",
                new DialogueElement[] {
                    new DialogueElement(true, "YOU WANT IT SO BAD! WELL FINE, IT'S NOT EVEN USEFUL FOR YOUR CASE!"),
                }
            ) },
            { nameof(MeleenaHeardRaymondsVoice), new DialogueSequence(
                "Whom Meleena Heard.",
                new DialogueElement[] {
                    new DialogueElement(true, "I have something private to tell you."),
                    new DialogueElement(true, "He is the one I heard on the ship. Raymond's voice was definitely the voice I heard."),
                }
            ) },
            { nameof(YouAreAHacker), new DialogueSequence(
                "You are not a corporate freelancer and this is not a retreat.",
                new DialogueElement[] {
                    new DialogueElement(true, "You're right, I was hired to find dirt on Human Perfect."),
                    new DialogueElement(true, "CEO's don't take time off to small time resorts. But that means that something fishy is up and an easy to access to the CEO's data. \nEasy mark."),
                }
            ) },
            #endregion

            #region Travis
            { nameof(DidYouWorkWithRaymond), new DialogueSequence(
                "Do you work with Raymond at Human Perfect?",
                new DialogueElement[] {
                    new DialogueElement(true, "Not directly, but I'm a researcher working under him in R/D."),
                }
            ) },
            { nameof(WhyIsTravisAtTheResort), new DialogueSequence(
                "Why are you present at this space resort?",
                new DialogueElement[] {
                    new DialogueElement(true, "I was brought by Raymond to secretly make him his clone."),
                    new DialogueElement(true, "Speaking of which I don't see Raymond's clone present."),
                    new DialogueElement(true, "I am tracking his location to a vacant resort room with a tracking chip embedded when I created him."),
                }
            ) },
            { nameof(TravissAccount), new DialogueSequence(
                "Tell me everything leading up to now?",
                new DialogueElement[] {
                    new DialogueElement(true, "I'm still curious what kind of crime was commited."),
                    new DialogueElement(true, "Well I can say that I begun cloning Raymond at 5 PM, and that the process was finished at about 6:30"),
                    new DialogueElement(true, "Then Raymond and his newly formed clone took off."),
                    new DialogueElement(true, "A few hours later Officer Warren knocked at my door and escorted me to the lobby"),
                }
            ) },
            { nameof(InvestigateYourCloningMachine), new DialogueSequence(
                "I'm going to need to investigate your cloning machine.",
                new DialogueElement[] {
                    new DialogueElement(true, "Of course, but first you have to sign a non-disclosure agreement to not divulge any of the methods used by the machine to perform the cloning."),
                    new DialogueElement(true, "I will be waiting for you at my room so that I can explain it to you."),
                }
            ) },
            { nameof(YourBrotherWasKilled), new DialogueSequence(
                "Your brother died in a cloning experiment and Raymond covered it up.",
                new DialogueElement[] {
                    new DialogueElement(true, "So you think this would be my motive for murder?"),
                    new DialogueElement(true, "Well it's even worse than a cover up, my brother told Raymond the experiment wasn't ready."),
                    new DialogueElement(true, "But Raymond wasn't willing to delay it, he rushed it in an unsafe manner."),
                    new DialogueElement(true, "How is that for a strong motive, although you will find the evidence doesn't support me being the murder."),
                }
            ) },
            { nameof(ViolentExperimentalResearch), new DialogueSequence(
                "The technique used by this cloning chamber is the same one used in the incident that killed your brother.",
                new DialogueElement[] {
                    new DialogueElement(true, "Even though the experiment resulted in a massacre, it did produce results and we were able to perfect it with out the lethal flaw."),
                    new DialogueElement(true, "This is the same method without that flaw."),
                }
            ) },
            #endregion

            #region Raymond's Clone
            { nameof(MeetingRaymondsClone), new DialogueSequence(
                "Meeting Raymond",
                new DialogueElement[] {
                    new DialogueElement(true, "You are with the police. You have got to hear me out. I had my researcher Travis make a clone of me."),
                    new DialogueElement(true, "But when the process was done, I had a tracking chip embedded in me."),
                    new DialogueElement(true, "Travis was trying to make me look like the clone and replace me to take control of Human Perfect."),
                    new DialogueElement(true, "Travis could control the clone, and he made my clone try to kill me."),
                    new DialogueElement(true, "I was chased into the docking bay where the clone tried to shoot me with my own blaster."),
                    new DialogueElement(true, "The blaster requires my DNA to use but the clone shares my DNA."),
                    new DialogueElement(true, "Thankfully I'm a poor shot, which makes my clone a poor shot as well."),
                    new DialogueElement(true, "I managed to get out of there and hid myself in this room."),
                }
            ) },
            { nameof(YourLookALikeIsDead), new DialogueSequence(
                "Your stunt double is dead.",
                new DialogueElement[] {
                    new DialogueElement(true, "Good, that means he won't try to kill me again."),
                }
            ) },
            { nameof(GoToTheLobby), new DialogueSequence(
                "Head to the lobby, Officer Warren well ensure your safety.",
                new DialogueElement[] {
                    new DialogueElement(true, "Alright, I'll make sure to head on over there."),
                }
            ) },
            { nameof(DidYouChokeYourClone), new DialogueSequence(
                "When your clone tried to kill you, did you manage to get a chokehold on him?",
                new DialogueElement[] {
                    new DialogueElement(true, "..."),
                    new DialogueElement(true, "Yes I did, I managed to get the upper hand on him for a moment."),
                }
            ) },
            { nameof(MeleenaIdentifiedYourVoice), new DialogueSequence(
                "Meleena heard you in Raymonds space craft. When you took it for a spin.",
                new DialogueElement[] {
                    new DialogueElement(true, "..."),
                    new DialogueElement(true, "Alright I lied, truth is when I was chased into the docking bay I got hit with a bolt of electricity that knocked out my senses as I writhed on the ground."),
                    new DialogueElement(true, "I was watching my clone so it had to come from somewhere else."),
                    new DialogueElement(true, "When I had gained back my senses, I saw the clones body floating in space with a bunch of garbage"),
                    new DialogueElement(true, "I got in my ship to save him, but when I brought him aboard the ship he was dead."),
                    new DialogueElement(true, "I didn't want to be blamed for the murder so I landed the ship and ran away."),
                }
            ) },
            #endregion
        };

        private static DictionaryWithDefault<string, string> _dilemmaOrDeductionText = new DictionaryWithDefault<string, string>("This dilemma or deduction is not implemented") {
            { nameof(WhoWasTheMurderer), "Who killed \\Raymond\\?" },
            { nameof(ZaidWasTheCulprit), "Zaid" },
            { nameof(MeleenaWasTheCulprit), "Meleena" },
            { nameof(TravisWasTheCulprit), "Travis" },
            { nameof(RaymondsCloneWasTheCulprit), "\\NotRaymond\\" },
            { nameof(TravisAndRaymondsCloneAreTheCulprits), "Travis used Raymond's Clone" },

            { nameof(WhatWasTheCauseOfDeath), "What was the victim's cause of death?" },
            { nameof(ChokedBySomeone), "The victim was choked to death prior to his exposure to space" },
            { nameof(PushedOutOfHisShip), "The victim was pushed into space from his ship" },
            { nameof(PoisonNeedles), "The victim died from his lungs giving out due to poison needles" },
            { nameof(LaunchedIntoSpaceFromTheGarbageAirlock), "The victim was launched into space from the garbage airlock" },

            { nameof(WhatWasTheCulpritsMotive), "What was the culprits motive?" },
            { nameof(MeleenaGotCaught), "Meleena was discovered on Raymond's ship and rather than go to prison she killed him" },
            { nameof(MeleenaKilledHimBecauseHeIsEvil), "Meleena had discovered that he covered up a massacre within his company" },
            { nameof(RaymondsCloneWasDesignedToKillForRevenge), "Travis blames Raymond for the death of his brother, so he made a murderous clone" },
            { nameof(RaymondsCloneWasDesignedToKillAndThenControlHumanPerfectByProxy), "Travis wanted to control Human Perfect, so he made a clone to replace Raymond" },
            { nameof(RaymondWasDefendingHimself), "Raymond was attacked by the murderous clone and defended himself." },
            { nameof(RevengeForHisBrothersDeath), "Travis blames Raymond for the death of his brother." },
            { nameof(ToFrameRaymondAndMakeHimLookLikeAClone), "Travis blamed Raymond for his brothers death, so he wanted to imprison and humiliate Raymond" },
            { nameof(ToReplaceRaymondAsCEO), "Raymond's clone wasn't satisfied pretending to be the CEO. He decided he was going to replace Raymond." },
            { nameof(ToSaveHisResort), "Zaid needed his resort to be accepted for resort clones beta-testing" },

            { nameof(WhoIsTheVictim), "Who was the victim?" },
            { nameof(TheVictimIsRaymond), "Raymond" },
            { nameof(TheVictimIsRaymondsClone), "Raymond's Clone" },

            { nameof(WhatWasTheTimeFrameForTheMurder), "When did the murder take place?" },
            { nameof(FromAnytimeUntilEightPM), "It could have happened on any day or any time before 8 PM tonight" },
            { nameof(SevenAMToEightPM), "It must have happened between 7 AM and 8 PM today" },
            { nameof(EightPMtoMidnight), "It has to be 8 PM until midnight tonight, so we have to hurry" },

            { nameof(WhoShotRaymondsShip), "Who shot Raymond's ship?" },
            { nameof(RaymondShotHisOwnShip), "Raymond" },
            { nameof(ZaidShotRaymondsShip), "Zaid" },
            { nameof(MeleenaShotRaymondsShip), "Meleena" },
            { nameof(TravisShotRaymondsShip), "Travis" },
            { nameof(RaymondsCloneShotRaymondsShip), "Raymond's clone" },

            { nameof(WhoHackedTheDoor), "Who hacked the door on Raymond's craft?" },
            { nameof(MeleenaHackedTheDoor), "Meleena" },
            { nameof(TravisHackedTheDoor), "Travis" },
            { nameof(ZaidHackedTheDoor), "Zaid" },

            { nameof(WasZaidsResortAcceptedAsABetaTester), "Was Zaid's resort accepted for the beta testing program?" },
            { nameof(ZaidsResortAccepted), "His resort was accepted, because of the message on Raymond's pad." },
            { nameof(ZaidsResortDeclined), "His resort was declined, Zaid's resort was crossed off." },
            
            { nameof(WasMeleenaTellingTheTruthAboutWhatHappenedOnRaymondsShip), "Was Meleena honest in what happened on Raymond's ship." },
            { nameof(MeleenaWasHonest), "Yes" },
            { nameof(MeleenaIsLying), "No, Something about her testimony is off." },

            { nameof(WhoLaunchedTheShip), "Who launched Raymond's craft" },
            { nameof(ZaidLaunchedTheShip), "Zaid" },
            { nameof(MeleenaLaunchedTheShip), "Meleena" },
            { nameof(TravisLaunchedTheShip), "Travis" },
            { nameof(RaymondLaunchedTheShip), "\\Raymond\\ did before his death" },
            { nameof(RaymondsCloneLaunchedTheShip), "\\NotRaymond\\" },

            { nameof(WasTheCloneDesignedToKill), "Was the clone designed to kill his look a like?" },
            { nameof(DesignedToKill), "Yes, Travis intentionally used a process that would create a killer clone" },
            { nameof(PerfectedDesign), "No, the new cloning process was perfected." }
        };

        private static DictionaryWithDefault<string, string> _objectiveNames = new DictionaryWithDefault<string, string>("This objective is not implemented") {
            { nameof(LookAroundForClues), "Look around this ship for clues." },
            { nameof(AnswerADilemma), "Answer a dilemma located in the top right corner." },
            { nameof(InvestigateRaymondsDeadBody), "Investigate Raymond's Ship" },
            { nameof(InvestigateMeleenasCraft), "Investigate Meleena's Craft" },
            { nameof(GetAnEncryptionKeyForMeleenasDataStick), "Get Meleena's Data Encryption Key" },
            { nameof(CheckWhatsOnMeleenasDataStick), "Decrypt Meleena's Data Stick" },
        };

        private static DictionaryWithDefault<string, string> _resolutionQuestionsText = new DictionaryWithDefault<string, string>("This option is not implemented") {
            { nameof(IAmLeaving), "I am leaving" }
        };

        private static DictionaryWithDefault<string, string> _pathwayText = new DictionaryWithDefault<string, string>("This pathway should not be stopping you"){
            { nameof(PoliceCruiserToDockingBay), "I am not ready yet." }
        };

        private static Dictionary<string, Func<string>> _symbols = new Dictionary<string, Func<string>> {
            { "Raymond",
                () => CurrentGameState.IsThinking(nameof(TheVictimIsRaymondsClone))
                    ? "Raymond's Clone"
                    : "Raymond"
            },
            { "NotRaymond",
                () => CurrentGameState.IsThinking(nameof(TheVictimIsRaymondsClone))
                    ? "Raymond"
                    : "Raymond's Clone"
            },
            { "Player",
                () => "Zavix"
            },
        };
    }
}
