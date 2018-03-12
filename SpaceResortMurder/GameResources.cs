using SpaceResortMurder.Clues;
using SpaceResortMurder.ObjectivesX;
using System;
using System.Collections.Generic;
using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.Deductions.CauseOfDeath;
using SpaceResortMurder.Deductions.EnteredSpaceFrom;
using SpaceResortMurder.Deductions.ZaidsResortForBetaTesting;
using SpaceResortMurder.Dialogs.Meleena;
using SpaceResortMurder.Dialogs.Warren;
using SpaceResortMurder.Dialogs.Zaid;
using SpaceResortMurder.DilemmasX;
using SpaceResortMurder.ResolutionsX;

namespace SpaceResortMurder
{
    public static class GameResources
    {
        public const string MainMenuSceneName = "Main Menu";
        public const string OptionsSceneName = "Options";
        public const string CreditsSceneName = "Credits";
        public const string DilemmasSceneName = "Dilemmas";
        public const string MapSceneName = "Map";
        public const string ObjectivesSceneName = "Objectives";
        public const string DialogueMemoriesScene = "Dialog Memories";
        public const string ResolutionSceneName = "Resolution";

        private static string[] _notImplementedClueLines = new string[] { "This clue hasn't been implemented" };
        public static string[] GetClueLines(string dialogOrClue)
        {
            if (_clues.ContainsKey(dialogOrClue))
                return _clues[dialogOrClue];
            return _notImplementedClueLines;
        }

        private const string _notImplementedDilemmaOrDeductionText = "This dilemma or deduction hasn't been implemented";
        public static string GetDilemmaOrDeductionText(string dilemmaOrDeduction)
        {
            if (_dilemmaOrDeductionText.ContainsKey(dilemmaOrDeduction))
                return _dilemmaOrDeductionText[dilemmaOrDeduction];
            return _notImplementedDilemmaOrDeductionText;
        }

        private const string _notImplementedObjectiveText = "This objective hasn't been implemented";
        public static string GetObjectiveName(string objective)
        {
            if (_objectiveTexts.ContainsKey(objective))
                return _objectiveTexts[objective].Item1;
            return _notImplementedObjectiveText;
        }
        public static string GetObjectiveDescription(string objective)
        {
            if (_objectiveTexts.ContainsKey(objective))
                return _objectiveTexts[objective].Item2;
            return _notImplementedObjectiveText;
        }

        private const string _notImplementedDialogText = "This dialog hasn't been implemented";
        public static string GetDialogOpener(string dialog)
        {
            if (_dialogs.ContainsKey(dialog))
                return _dialogs[dialog].Item1;
            return _notImplementedDialogText;
        }
        private static string[] _notImplementedDialogLines = new string[] { "This dialog hasn't been implemented" };
        public static string[] GetDialogLines(string dialog)
        {
            if (_dialogs.ContainsKey(dialog))
                return _dialogs[dialog].Item2;
            return _notImplementedDialogLines;
        }

        private const string _notImplementedResolution = "This resolution hasn't been implemented";
        public static string GetResolutionText(string resolution)
        {
            if (_resolutionText.ContainsKey(resolution))
                return _resolutionText[resolution];
            return _notImplementedResolution;
        }

        private static Dictionary<string, string[]> _clues = new Dictionary<string, string[]>() {
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
        };

        private static Dictionary<string, Tuple<string, string[]>> _dialogs = new Dictionary<string, Tuple<string, string[]>> {
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
            { nameof(INeedASearchOrder), new Tuple<string, string[]>(
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
            #endregion
        };

        private static Dictionary<string, string> _dilemmaOrDeductionText = new Dictionary<string, string>() {
            { nameof(WhoShotRaymondsShip), "Who shot Raymond's ship?" },
            { nameof(WhoHackedTheDoor), "Who hacked the door on Raymond's craft?" },
            { nameof(WhereDidHeEnterSpaceFrom), "Where did he enter space from?" },
            { nameof(WhatWasTheCauseOfDeath), "What was the victim's cause of death?" },
            { nameof(WasZaidsResortAcceptedAsABetaTester), "Was Zaid's resort accepted for the beta testing program?" },

            { nameof(RaymondShotHisOwnShip), "Raymond" },
            { nameof(ZaidShotRaymondsShip), "Zaid" },
            { nameof(MeleenaShotRaymondsShip), "Meleena" },
            { nameof(TravisShotRaymondsShip), "Travis" },
            { nameof(RaymondsCloneShotRaymondsShip), "Raymond's clone" },
            { nameof(MeleenaHackedTheDoor), "Meleena" },
            { nameof(TravisHackedTheDoor), "Travis" },
            { nameof(ZaidHackedTheDoor), "Zaid" },
            { nameof(ChokedBySomeone), "He was choked to death prior to his exposure to space" },
            { nameof(LackOfOxygenInSpace), "The victim was pushed into space died while in space" },
            { nameof(PoisonNeedles), "Poison needles were his hidden killer" },
            { nameof(CameFromHisShip), "He was pushed out of his ship into space without a suit" },
            { nameof(CameFromtheGarbageAirlock), "He was launched from the garbage airlock in the docking bay" },
            { nameof(ZaidsResortAccepted), "His resort was accepted, because of the message on Raymond's pad." },
            { nameof(ZaidsResortDeclined), "His resort was declined, Zaid's resort was crossed off." },
        };

        private static Dictionary<string, Tuple<string, string>> _objectiveTexts = new Dictionary<string, Tuple<string, string>>()
        {
            { nameof(InvestigateRaymondsDeadBody), new Tuple<string, string>(
                "Go to Raymond's ship and investigate his remains",
                "According to Warren, Raymond died earlier tonight and his body was found within his space craft. I should see what I can find from his remains."
            )},
        };

        private static Dictionary<string, string> _resolutionText = new Dictionary<string, string>()
        {
            { nameof(IAmLeaving), "I am leaving" }
        };
    }
}
