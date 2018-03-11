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
            { nameof(Necronomicon), new string[] {
                "This necronomicon feels super out of place for a sci-fi murder mystery",
                "lazy writers"
            } },
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
        };

        private static Dictionary<string, string> _dilemmaOrDeductionText = new Dictionary<string, string>() {
            { nameof(WhoKilledRaymond), "Who Killed Raymond?" },
            { nameof(YouButcheredRaymond), "You brutally slain Raymond!!!" },
            { nameof(RaymondCommittedSuicide), "Raymond killed himself!!" },
        };

        private static Dictionary<string, Tuple<string, string>> _objectiveTexts = new Dictionary<string, Tuple<string, string>>()
        {
            { nameof(InvestigateRaymondsDeadBody), new Tuple<string, string>(
                "Investigate Raymond's dead body",
                "Raymond was found dead on his personal space craft at around 8 PM last night"
            )}
        };
    }
}
