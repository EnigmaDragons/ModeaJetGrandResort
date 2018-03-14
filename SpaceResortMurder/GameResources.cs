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
using SpaceResortMurder.Deductions.ClonesDesign;
using SpaceResortMurder.Deductions.LaunchedTheShip;

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

        public static void TestDilemmaAndDeductionSymbols()
        {
            foreach (var pair in _dilemmaOrDeductionText)
            {
                if (pair.Value.Where(c => c == '\\').Count() % 2 == 1)
                    throw new FormatException("A dilemma or deduction uses the reserved character '\\' improperly, you are suppose to use them in pairs with the text evaluation symbol between them");
                var matches = Regex.Matches(pair.Value, "\\\\([^\\\\]*)\\\\");
                foreach (Match match in matches)
                    foreach (Capture capture in match.Captures)
                        // The first capture is the whole value not a value caught by the capture zone
                        if (!capture.Value.Contains("\\") && !_symobls.ContainsKey(capture.Value))
                            throw new NotImplementedException("A dilemma or deduction uses unimplemented symbol \"" + capture + "\"");
            }
        }

        private static string[] _notImplementedClueLines = new string[] { "This clue hasn't been implemented" };
        public static string[] GetClueLines(string dialogOrClue)
        {
            if (_clues.ContainsKey(dialogOrClue))
                return _clues[dialogOrClue].Select(ReplaceSymbols).ToArray();
            return _notImplementedClueLines;
        }

        private const string _notImplementedDilemmaOrDeductionText = "This dilemma or deduction hasn't been implemented";
        public static string GetDilemmaOrDeductionText(string dilemmaOrDeduction)
        {
            if (_dilemmaOrDeductionText.ContainsKey(dilemmaOrDeduction))
                return ReplaceSymbols(_dilemmaOrDeductionText[dilemmaOrDeduction]);
            return _notImplementedDilemmaOrDeductionText;
        }

        private const string _notImplementedObjectiveText = "This objective hasn't been implemented";
        public static string GetObjectiveName(string objective)
        {
            if (_objectiveTexts.ContainsKey(objective))
                return ReplaceSymbols(_objectiveTexts[objective].Item1);
            return _notImplementedObjectiveText;
        }
        public static string GetObjectiveDescription(string objective)
        {
            if (_objectiveTexts.ContainsKey(objective))
                return ReplaceSymbols(_objectiveTexts[objective].Item2);
            return _notImplementedObjectiveText;
        }

        private const string _notImplementedDialogueText = "This dialog hasn't been implemented";
        public static string GetDialogueOpener(string dialog)
        {
            if (_dialogues.ContainsKey(dialog))
                return ReplaceSymbols(_dialogues[dialog].Item1);
            return _notImplementedDialogueText;
        }
        private static string[] _notImplementedDialogueLines = new string[] { "This dialog hasn't been implemented" };
        public static string[] GetDialogueLines(string dialog)
        {
            if (_dialogues.ContainsKey(dialog))
                return _dialogues[dialog].Item2.Select(ReplaceSymbols).ToArray();
            return _notImplementedDialogueLines;
        }

        private const string _notImplementedResolution = "This resolution hasn't been implemented";
        public static string GetResolutionText(string resolution)
        {
            if (_resolutionText.ContainsKey(resolution))
                return ReplaceSymbols(_resolutionText[resolution].ToCharArray());
            return _notImplementedResolution;
        }

        private const string _notImplementedPathway = "This pathway hasn't been implemented";
        public static string GetPathwayText(string pathway)
        {
            if (_pathwayText.ContainsKey(pathway))
                return ReplaceSymbols(_pathwayText[pathway]);
            return _notImplementedPathway;
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
                            builder.Append(_symobls[symbol.ToString()]());
                            break;
                        }
                        else
                            symbol.Append(text[i]);
                }
                else
                    builder.Append(text[i]);
            return builder.ToString();
        }

        private static Dictionary<string, string[]> _clues = new Dictionary<string, string[]> {
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
        };

        private static Dictionary<string, Tuple<string, string[]>> _dialogues = new Dictionary<string, Tuple<string, string[]>> {
            #region Warren
            { nameof(MeetingWarren), new Tuple<string, string[]>(
                "Incident details",
                new string[] {
                    "Finally you made it!",
                    "The victim is Raymond Soule, the CEO of the lead cloning company Human Perfect.",
                    "He was found dead inside his personal space craft at 8 PM.",
                    "The only people present in the space resort according to the resort manager were.",
                    "On your left Zaid the resort manager, he was the one that called in about the incident.",
                    "In the middle we have a lead reasearcher at Human Perfect Travis Falcon.",
                    "And on the right Meleena Ke'lick, her file says she is a corporate freelancer. But currently she is not employed by any company."
                }
            ) },
            { nameof(NeedASearchOrder), new Tuple<string, string[]>(
                "I need a search order for Meleena's craft.",
                new string[] {
                    "I am way ahead of you, I sent out a request as soon as I got here. Here is your search order.",
                }
            ) },
            #endregion

            #region Zaid
            { nameof(WhyWasRaymondHere), new Tuple<string, string[]>(
                "Why was Raymond visiting your resort?",
                new string[] {
                    "Raymond was considering my resort for beta-testing Human Perfect's new clones specifically tailored for resorts.",
                }
            ) },
            { nameof(DidRaymondApproveYourResort), new Tuple<string, string[]>(
                "Did Raymond decide your resort was a good fit?",
                new string[] {
                    "My resort is terrific, of course he did.",
                }
            ) },
            { nameof(DidYouReleaseTheGarbage), new Tuple<string, string[]>(
                "I noticed that the garbage airlock was recently used, was that you?",
                new string[] {
                    "No I thought it was strange the garbage airlock was empty.",
                }
            ) },
            { nameof(WhySoFewPeopleAtTheResort), new Tuple<string, string[]>(
                "Your resort seems to be lacking in occupants?",
                new string[] {
                    "It's been a rough year. Nothing I can't fix with a little effort.",
                }
            ) },
            { nameof(ZaidsAccount), new Tuple<string, string[]>(
                "Please tell me as detailed as you can remember what you can recall?",
                new string[] {
                    "I was staying in my room when I got a notification that Raymond's ship was leaving.",
                    "I didn't find that odd until 20 minutes after it left, Raymond's ship was landing.",
                    "I headed over to the docking bay. That's where I saw Raymond's ship was open.",
                    "Upon coming over I saw Raymond's dead body and then immidiately called you."
                }
            ) },
            { nameof(YouWereNotAcceptedForBetaTesting), new Tuple<string, string[]>(
                "You were not accepted for beta testing, I found a list of resorts and yours was crossed off?",
                new string[] {
                    "But what about the message Raymond sent!",
                    "Oh wait I shouldn't know about that...",
                    "Alright truth is when I found Raymond's body I sent the message on his pad.",
                    "I needed this, to keep my place running, But I didn't kill him.",
                }
            ) },
            #endregion

            #region Meleena
            { nameof(MeleenasAccount), new Tuple<string, string[]>(
                "Please give my your account of today up until being brought by Officer Warren.",
                new string[] {
                    "I take some kind of crime has been commited.", 
                    "I have been in my room relaxing and taking calls all day, I don't know anything."
                }
            ) },
            { nameof(WhatIsACorporateFreelancerDoingHere), new Tuple<string, string[]>(
                "Why are you visiting this resort?",
                new string[] {
                    "Between jobs I like to get some rest and relaxation.",
                }
            ) },
            { nameof(CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts), new Tuple<string, string[]>(
                "Corporate freelancers can't normally afford to own a space craft.",
                new string[] {
                    "I'm a research specialist, tasked with gather invaluable market date.",
                    "You'd be surprised how well one gets paid when they are as good as me.",
                }
            ) },
            { nameof(SearchYourCraftForEvidence), new Tuple<string, string[]>(
                "We are going to need to check your craft for evidence.",
                new string[] {
                    "You are going to need a search order for that!",
                }
            ) },
            { nameof(ImOnlyInvestigatingTheMurder), new Tuple<string, string[]>(
                "I'm only investigating the murder, I don't care what other illegal activities you are up to.",
                new string[] {
                    "You could probably get your search order anyway.",
                    "Alright I'm trusting you. I have unlocked my craft.",
                }
            ) },
            { nameof(HereIsTheSearchOrder), new Tuple<string, string[]>(
                "Here is the search order for your ship. You can open it or we can force entry.",
                new string[] {
                    "You piece of junk, go on and destroy any shred of privacy us citizens have.",
                }
            ) },
            { nameof(YouBrokeIntoRaymondsShip), new Tuple<string, string[]>(
                "You broke into Raymond's craft with this skeleton key.",
                new string[] {
                    "Alright I broke into his ship to find dirt on Human Perfect.",
                    "Just when I was going to leave, I felt the blast of something shoot the ship.",
                    "I quickly hid in a storage container and then quite some time later a male with a deep voice came in muttering to himself.",
                    "He took off with the ship. Shortly after he opened up the space hatch, and left.",
                    "I was curious so i peeked out of my hiding spot in time to see Raymond's corpse dropped into the ship.",
                    "Startled I quickly sealed my container again. Before the man returned into the ship.",
                    "He quickly landed the ship while cursing and took off out of the ship.",
                    "As soon as he left I booked it.",
                }
            ) },
            { nameof(CareToShowTheDirtYouCollected), new Tuple<string, string[]>(
                "This data stick shows signs of recent use, care to give me the encryption key?",
                new string[] {
                    "There is some juicy pieces of dirt on Human Perfect and the shady Mr.Soule.",
                    "Here is your encryption key.",
                }
            ) },
            { nameof(YouNeedToUnencryptThisDataStick), new Tuple<string, string[]>(
                "The data stick on your craft has evidence, give me the encryption key.",
                new string[] {
                    "Oh that's so sad, I lost the encryption key, and it would take the best AIs 290 years to crack. So good luck!",
                }
            ) },
            { nameof(WontTurnYouInIfYouUnencryptThisDrive), new Tuple<string, string[]>(
                "I don't have to report your career choices, if you can give me the encryption for the drive.",
                new string[] {
                    "Now you're talking, I hope I'm right about you being honest.",
                }
            ) },
            { nameof(ObstructionOfJusticeWillAddToYourPrisonTime), new Tuple<string, string[]>(
                "Obstruction of justice will only extend your prison time.",
                new string[] {
                    "YOU WANT IT SO BAD! WELL FINE, IT'S NOT EVEN USEFUL FOR YOUR CASE!",
                }
            ) },
            { nameof(MeleenaHeardRaymondsVoice), new Tuple<string, string[]>(
                "Whom Meleena Heard.",
                new string[] {
                    "I have something private to tell you.",
                    "He is the one I heard on the ship. Raymond's voice was definitely the voice I heard.",
                }
            ) },
            { nameof(YouAreAHacker), new Tuple<string, string[]>(
                "You are not a corporate freelancer and this is not a retreat.",
                new string[] {
                    "You're right, I was hired to find dirt on Human Perfect.",
                    "CEO's don't take time off to small time resorts. But that means that something fishy is up and an easy to access to the CEO's data. \nEasy mark.",
                }
            ) },
            #endregion

            #region Travis
            { nameof(DidYouWorkWithRaymond), new Tuple<string, string[]>(
                "Do you work with Raymond at Human Perfect?",
                new string[] {
                    "Not directly, but I'm a researcher working under him in R/D.",
                }
            ) },
            { nameof(WhyIsTravisAtTheResort), new Tuple<string, string[]>(
                "Why are you present at this space resort?",
                new string[] {
                    "I was brought by Raymond to secretly make him his clone.",
                    "Speaking of which I don't see Raymond's clone present.",
                    "I am tracking his location to a vacant resort room with a tracking chip embedded when I created him."
                }
            ) },
            { nameof(TravissAccount), new Tuple<string, string[]>(
                "Tell me everything leading up to now?",
                new string[] {
                    "I'm still curious what kind of crime was commited.",
                    "Well I can say that I begun cloning Raymond at 5 PM, and that the process was finished at about 6:30",
                    "Then Raymond and his newly formed clone took off.",
                    "A few hours later Officer Warren knocked at my door and escorted me to the lobby",
                }
            ) },
            { nameof(InvestigateYourCloningMachine), new Tuple<string, string[]>(
                "I'm going to need to investigate your cloning machine.",
                new string[] {
                    "Of course, but first you have to sign a non-disclosure agreement to not divulge any of the methods used by the machine to perform the cloning.",
                    "I will be waiting for you at my room so that I can explain it to you.",
                }
            ) },
            { nameof(YourBrotherWasKilled), new Tuple<string, string[]>(
                "Your brother died in a cloning experiment and Raymond covered it up.",
                new string[] {
                    "So you think this would be my motive for murder?",
                    "Well it's even worse than a cover up, my brother told Raymond the experiment wasn't ready.",
                    "But Raymond wasn't willing to delay it, he rushed it in an unsafe manner.",
                    "How is that for a strong motive, although you will find the evidence doesn't support me being the murder.",
                }
            ) },
            { nameof(ViolentExperimentalResearch), new Tuple<string, string[]>(
                "The technique used by this cloning chamber is the same one used in the incident that killed your brother.",
                new string[] {
                    "Even though the experiment resulted in a massacre, it did produce results and we were able to perfect it with out the lethal flaw.",
                    "This is the same method without that flaw.",
                }
            ) },
            #endregion

            #region Raymond's Clone
            { nameof(MeetingRaymondsClone), new Tuple<string, string[]>(
                "Meeting Raymond",
                new string[] {
                    "You are with the police. You have got to hear me out. I had my researcher Travis make a clone of me.",
                    "But when the process was done, I had a tracking chip embedded in me.",
                    "Travis was trying to make me look like the clone and replace me to take control of Human Perfect.",
                    "Travis could control the clone, and he made my clone try to kill me.",
                    "I was chased into the docking bay where the clone tried to shoot me with my own blaster.",
                    "The blaster requires my DNA to use but the clone shares my DNA.",
                    "Thankfully I'm a poor shot, which makes my clone a poor shot as well.",
                    "I managed to get out of there and hid myself in this room.",
                }
            ) },
            { nameof(YourLookALikeIsDead), new Tuple<string, string[]>(
                "Your stunt double is dead.",
                new string[] {
                    "Good, that means he won't try to kill me again.",
                }
            ) },
            { nameof(GoToTheLobby), new Tuple<string, string[]>(
                "Head to the lobby, Officer Warren well ensure your safety.",
                new string[] {
                    "Alright, I'll make sure to head on over there.",
                }
            ) },
            { nameof(DidYouChokeYourClone), new Tuple<string, string[]>(
                "When your clone tried to kill you, did you manage to get a chokehold on him?",
                new string[] {
                    "...",
                    "Yes I did, I managed to get the upper hand on him for a moment."
                }
            ) },
            { nameof(MeleenaIdentifiedYourVoice), new Tuple<string, string[]>(
                "Meleena heard you in Raymonds space craft. When you took it for a spin.",
                new string[] {
                    "...",
                    "Alright I lied, truth is when I was chased into the docking bay I got hit with a bolt of electricity that knocked out my senses as I writhed on the ground.",
                    "I was watching my clone so it had to come from somewhere else.",
                    "When I had gained back my senses, I saw the clones body floating in space with a bunch of garbage",
                    "I got in my ship to save him, but when I brought him aboard the ship he was dead.",
                    "I didn't want to be blamed for the murder so I landed the ship and ran away.",
                }
            ) },
            #endregion
        };

        private static Dictionary<string, string> _dilemmaOrDeductionText = new Dictionary<string, string> {
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

        private static Dictionary<string, Tuple<string, string>> _objectiveTexts = new Dictionary<string, Tuple<string, string>>
        {
            { nameof(InvestigateRaymondsDeadBody), new Tuple<string, string>(
                "Investigate Raymond's Ship",
                "According to Warren, Raymond died earlier tonight and his body was found within his space craft. I should see what I can find from his remains."
            )},
            { nameof(InvestigateMeleenasCraft), new Tuple<string, string>(
                "Investigate Meleena's Craft",
                "Meleena's craft is pretty close to the murder scene and could be hiding evidence."
            )},
            { nameof(GetAnEncryptionKeyForMeleenasDataStick), new Tuple<string, string>(
                "Get Meleena's Data Encryption Key",
                "Found a data stick with signs of recent use. I am going to need Meleena to give me the encryption key to find out what's on it."
            )},
            { nameof(CheckWhatsOnMeleenasDataStick), new Tuple<string, string>(
                "Decrypt Meleena's Data Stick",
                "I can now find out what was on the data stick in Meleena's ship using this encryption key."
            )},
        };

        private static Dictionary<string, string> _resolutionText = new Dictionary<string, string>
        {
            { nameof(IAmLeaving), "I am leaving" }
        };

        private static Dictionary<string, string> _pathwayText = new Dictionary<string, string>
        {
            
        };

        private static Dictionary<string, Func<string>> _symobls = new Dictionary<string, Func<string>>
        {
            { "Raymond",
                () => CurrentGameState.Instance.IsThinking(nameof(TheVictimIsRaymondsClone))
                    ? "Raymond's Clone"
                    : "Raymond"
            },
            { "NotRaymond",
                () => CurrentGameState.Instance.IsThinking(nameof(TheVictimIsRaymondsClone))
                    ? "Raymond"
                    : "Raymond's Clone"
            },
        };
    }
}
