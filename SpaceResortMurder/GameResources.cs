using SpaceResortMurder.Clues;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.Dialogs;
using SpaceResortMurder.DilemmasX;
using SpaceResortMurder.ObjectivesX;
using System;
using System.Collections.Generic;

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

        private static string[] _notImplementedDialogOrClueLines = new string[] { "This dialog or clue hasn't been implemented" };
        public static string[] GetDialogOrClueLines(string dialogOrClue)
        {
            if (_dialogOrClueLines.ContainsKey(dialogOrClue))
                return _dialogOrClueLines[dialogOrClue];
            return _notImplementedDialogOrClueLines;
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

        private static Dictionary<string, string[]> _dialogOrClueLines = new Dictionary<string, string[]>() {
            { nameof(WhoWasMurdered), new string[] {
                "Raymond was murdered",
                "Sucks for him!"
            } },
            { nameof(WhyWouldAnyoneHireYouPolice), new string[] {
                "because im the best you scrub!"
            } },
            { nameof(DidYouKillHimZaid), new string[] {
                "No I did not!",
                "You seem suspicious"
            } },

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

        private static Dictionary<string, string> _dilemmaOrDeductionText = new Dictionary<string, string>() {
            { nameof(WhoKilledRaymond), "Who Killed Raymond?" },
            { nameof(YouButcheredRaymond), "You brutally slain Raymond!!!" },
            { nameof(RaymondCommittedSuicide), "Raymond killed himself!" },
        };

        private static Dictionary<string, Tuple<string, string>> _objectiveTexts = new Dictionary<string, Tuple<string, string>>()
        {
            { nameof(InvestigateRaymondsDeadBody), new Tuple<string, string>(
                "Investigate Raymond's dead body",
                "Raymond was found dead on his personal space craft at around 8 PM last night"
            )},
        };
    }
}
