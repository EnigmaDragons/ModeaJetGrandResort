using SpaceResortMurder.Clues;
using SpaceResortMurder.ObjectivesX;
using System;
using System.Collections.Generic;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.Dialogs.Warren;
using SpaceResortMurder.Dialogs.Zaid;
using SpaceResortMurder.DilemmasX;

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
        public const string DialogMemoriesScene = "Dialog Memories";

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

        private static Dictionary<string, string[]> _clues = new Dictionary<string, string[]>() {
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
            #endregion

            #region Meleena
            
            #endregion
        };

        private static Dictionary<string, string> _dilemmaOrDeductionText = new Dictionary<string, string>() {
            { nameof(WhoShotRaymondsShip), "Who shot Raymond's ship?" },
            { nameof(WhoHackedTheDoor), "Who hacked the door on Raymond's craft?" },

            { nameof(RaymondShotHisOwnShip), "Raymond" },
            { nameof(ZaidShotRaymondsShip), "Zaid" },
            { nameof(MeleenaShotRaymondsShip), "Meleena" },
            { nameof(TravisShotRaymondsShip), "Travis" },
            { nameof(RaymondsCloneShotRaymondsShip), "Raymond's clone" },
            { nameof(MeleenaHackedTheDoor), "Meleena" },
            { nameof(TravisHackedTheDoor), "Travis" },
            { nameof(ZaidHackedTheDoor), "Zaid" },
        };

        private static Dictionary<string, Tuple<string, string>> _objectiveTexts = new Dictionary<string, Tuple<string, string>>()
        {
            { nameof(InvestigateRaymondsDeadBody), new Tuple<string, string>(
                "Go to Raymond's ship and investigate his remains",
                "According to Warren, Raymond died earlier tonight and his body was found within his space craft. I should see what I can find from his remains."
            )},
        };
    }
}
