using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.Text;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Dialogues;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Scenes
{
    public class EndingScene : IScene
    {
        private ClickUI _clickUI;
        private ChatBox _chatBox;
        private VisualClickableUIElement _credits;

        private const string _newLines = " \n \n";
        private bool _wasMeleenaTheCulprit;
        private bool _wasZaidTheCulprit;
        private bool _wasRaymondAloneTheCulprit;
        private bool _wasTravisTheCulprit;
        private bool _wasRaymondsCloneTheCulprit;
        private bool _isRaymondsCloneRunningHumanFirst;
        private bool _isTravisArrested;
        private bool _isZaidArrested;
        private bool _isMeleenaArrested;
        private bool _isTravisCFO;
        private bool _isZaidsResortChosenForLuxuryClones;
        private bool _doesHumanPerfectGetABreakthrough;
        private int _humanPerfectScore = 0;

        public void Init()
        {
            _clickUI = new ClickUI();
            _credits = UiButtons.Menu("Credits", new Vector2(UI.OfScreenWidth(0.5f) - 180, 900), () => Scene.NavigateTo(GameResources.CreditsSceneName));
            _chatBox = new ChatBox("", 1670, DefaultFont.Value, CurrentOptions.MillisPerTextCharacter, 32) { SoundsEnabled = false };
            _clickUI.Add(_credits);
            _clickUI.Add(new ScreenClickable(_chatBox.CompletelyDisplayMessage));
            CalculateLinchPins();
            GenerateWallOfText();
        }

        public void Update(TimeSpan delta)
        {
            _clickUI.Update(delta);
            _chatBox.Update(delta);
        }

        public void Draw()
        {
            _credits.Draw();
            _chatBox.Draw(new Transform2(new Vector2(125, 75), Size2.Zero));
        }

        private void CalculateLinchPins()
        {
            _wasMeleenaTheCulprit = CurrentGameState.IsThinking(nameof(MeleenaWasTheCulprit));
            _wasZaidTheCulprit = CurrentGameState.IsThinking(nameof(ZaidWasTheCulprit));
            _wasRaymondAloneTheCulprit = CurrentGameState.IsThinking(nameof(RaymondsCloneWasTheCulprit));
            _wasTravisTheCulprit = CurrentGameState.IsThinking(nameof(TravisWasTheCulprit)) || CurrentGameState.IsThinking(nameof(TravisAndRaymondsCloneAreTheCulprits));
            _wasRaymondsCloneTheCulprit = CurrentGameState.IsThinking(nameof(RaymondsCloneWasTheCulprit)) || CurrentGameState.IsThinking(nameof(TravisAndRaymondsCloneAreTheCulprits));
            _isRaymondsCloneRunningHumanFirst = !_wasRaymondsCloneTheCulprit && CurrentGameState.IsThinking(nameof(YouCanKeepYourLife));
            _isTravisArrested = _wasTravisTheCulprit || CurrentGameState.IsThinking(nameof(YouAreStillResposible));
            _isZaidArrested = _wasZaidTheCulprit || CurrentGameState.IsThinking(nameof(YouBroughtThisOnYourself));
            _isMeleenaArrested = _wasMeleenaTheCulprit || CurrentGameState.IsThinking(nameof(DeckersMakeTheWorldWorse));
            _isTravisCFO = !_wasTravisTheCulprit && !_isRaymondsCloneRunningHumanFirst;
            _isZaidsResortChosenForLuxuryClones = !_isZaidArrested && !_isRaymondsCloneRunningHumanFirst;
            _doesHumanPerfectGetABreakthrough = _isTravisCFO && !_isMeleenaArrested;
        }

        private void GenerateWallOfText()
        {
            var wall = GenerateDeathHeader() 
                + GenerateTravisConclusion()
                + GenerateWasZaidArrested()
                + GenerateLuxuryClones()
                + GenerateMeleenaConclusion()
                + GenerateDataRavenFallout()
                + GenerateTravisBreakthrough()
                + GenerateZaidConclusion()
                + GenerateAmazingRazeResortFlop()
                + GenerateHumanPerfectFooter();
            _chatBox.ShowMessage(wall);
        }

        private string GenerateDeathHeader()
        {
            var deathHeader = "REPORT THIS TO DEVS";

            var murdererLine = "REPORT THIS TO DEVS";
            if (_wasMeleenaTheCulprit)
                murdererLine = "Meleena Ka'lick who turns out to be the infamous Data Raven. This is just another case of a cyber terrorist turned murderer.";
            else if (_wasZaidTheCulprit)
                murdererLine = "Zaid Ahuja a manager of the ModeaJet Grand Resort. Zaid couldn't handle having his resort denied for testing Raymond's new luxury clones.";
            else if (_wasTravisTheCulprit)
                murdererLine = "his Lead Researcher Travis Falcon, who recently had his brother die by a terroist attack.";

            if (_wasRaymondAloneTheCulprit)
            {
                deathHeader = "Raymond Soule, CEO of Human Perfect was murdered by a clone of himself. Customers of Human Perfect are in uproar that Human Perfect is making clones capable of killing. Human Perfect denies involvment claiming that Raymond Soule was operating behind their backs. Critics of Human Perfect say that it's perfect irony that he dies by his own evils.";
                _humanPerfectScore += -3;
            }
            else if (_wasRaymondsCloneTheCulprit && _wasTravisTheCulprit)
            {
                deathHeader = "Raymond Soule, CEO of Human Perfect was murdered by a killer clone designed by Lead Researcher Travis Falcon, who recently had his brother die in a terroist attack on Human Perfect.";
                _humanPerfectScore += -2;
            }
            else if (_isRaymondsCloneRunningHumanFirst)
            {
                deathHeader = $"Raymond Soule, CEO of Human Perfect had an attempt made on his life by {murdererLine} Fortunately they accidently killed Raymond Soule's clone. Raymond Soule personally thanks {CurrentGameState.PlayerName} for saving his life and putting the would be assassin on ice, with an alarming reward of 1 million credits.";
                _humanPerfectScore += 1;
            }
            else
            {
                deathHeader = $"Raymond Soule was murdered by {murdererLine} Raymond Soule had a clone made of himself before his death. Human Perfect has given the statement that they will not accept a clone to take Raymond's place as CEO. The clone will have to learn to fend for himself.";
                _humanPerfectScore += _wasTravisTheCulprit ? -1 : 0;
            }
                
            return deathHeader + _newLines;
        }

        private string GenerateTravisConclusion()
        {
            if (_wasTravisTheCulprit)
                return "";

            var travisConclusion = "REPORT THIS TO DEVS";

            if (_isTravisArrested)
            {
                travisConclusion = $"Detective {CurrentGameState.PlayerName} caught Travis Falcon, the lead researcher at Human Perfect using illegal cloning devices. Travis Falcon is facing 10 years in lockdown. This is just another testiment to the skill of bioroid detectives like {CurrentGameState.PlayerName}.";
                _humanPerfectScore += -2;
            }
                
            else if (_isRaymondsCloneRunningHumanFirst)
            {
                travisConclusion = "Travis Falcon is being let go by Raymond Soule, but his severance package will pay him a hefty some of credits every year for the rest of his life.";
                _humanPerfectScore += -1;
            }
            else
            {
                travisConclusion = "Travis Falcon has been promoted to Chief Research Officer, he says that his top priority is making sure research is done right from now on. Stakeholders have their doubts this decision will help the company.";
                _humanPerfectScore += -1;
            }

            return travisConclusion + _newLines;
        }

        private string GenerateWasZaidArrested()
        {
            if (_wasZaidTheCulprit)
                return "";

            return _isZaidArrested
                ? "Resort Manager Zaid Ahuja who was previously suspected of illegally selling his customers data, is now being arrested for fraud! He sent a message as Raymond Soule to approve his resort fro testing Human Perfect's new luxury clones." + _newLines
                : "";
        }

        private string GenerateLuxuryClones()
        {
            var luxuryClones = "REPORT THIS TO DEVS";

            if (_isRaymondsCloneRunningHumanFirst)
                luxuryClones = "Raymond Soule has declared that The Amazing Raze Resort will be testing Human Perfect's newest luxury clone.";
            else if (_isZaidArrested)
                luxuryClones = "Human Perfect has declared that The Amazing Raze Resort will be testing Human Perfect's newest luxury clone.";
            else 
                luxuryClones = "Before Raymond Soule's demise he decided ModeaJet Grand Resort would test out Human Perfect's new luxury clone.";

            return luxuryClones + _newLines;
        }

        private string GenerateMeleenaConclusion()
        {
            if (_wasMeleenaTheCulprit)
                return "";

            _humanPerfectScore += _isMeleenaArrested ? 0 : -4;
            var meleenaConclusion = _isMeleenaArrested 
                ? $"The infamous Data Raven was caught by {CurrentGameState.PlayerName} while investigating the death of Raymond Soule. An Impressive achievement early on in this bioroid's career." 
                : "Cyber Terrorist Data Raven strikes again, by exposing Human Perfect's illegal human experimentation that resulted in a massacre of their own researchers. In addition Raymond Soule covered it by staging a terroist attack.";
            return meleenaConclusion + _newLines;
        }

        private string GenerateDataRavenFallout()
        {
            if (_isMeleenaArrested)
                return "";

            var dataRavenFallout = "REPORT THIS TO DEVS";

            if (_isRaymondsCloneRunningHumanFirst)
            {
                dataRavenFallout = "Human Perfect tries to pin the human experiment massacre on Raymond Soule. Raymond Soule testifies to illegal corporate activities. Raymond Soule is now in witness protection as all of Human Perfect's executives are facing life sentences.";
                _humanPerfectScore += -5;
            }
            else if (_isTravisCFO)
            {
                dataRavenFallout =
                    "CFO Travis Falcon speaks out against the massacre that killed his brother. He will ensure as the new CFO that all experiments will be done in a legal and more importantly a safe manner.";
                _humanPerfectScore += 2;
            }
            else
            {
                dataRavenFallout = "Human Perfect in order to distance themselves from this human experiment massacre scandal has fired their entire R/D division.";
                _humanPerfectScore += -1;
            }

            return dataRavenFallout + _newLines;
        }

        private string GenerateTravisBreakthrough()
        {
            _humanPerfectScore += _doesHumanPerfectGetABreakthrough ? 4 : 0;
            return _doesHumanPerfectGetABreakthrough
                ? "Human Perfect releases a new cloning technique that can make far more perfect replications of the target than ever before. The implications are staggering, and all doubts from the stakeholders about their new CFO have been quelched." + _newLines
                : "";
        }

        private string GenerateZaidConclusion()
        {
            if (_isZaidArrested)
                return "";

            _humanPerfectScore += _isZaidsResortChosenForLuxuryClones ? 3 : 0;
            var zaidConclusion = _isZaidsResortChosenForLuxuryClones
                ? "ModeaJet Grand Resort has become the most popular resort in the region. Occupants rave about Human Perfect's luxury clones."
                : "Resort Manager Zaid Ahuja goes missing, he is rumored to have owed large sums of money to the Yakuza. Police speculate he is most likely dead.";
            return zaidConclusion + _newLines;
        }

        private string GenerateAmazingRazeResortFlop()
        {
            _humanPerfectScore += _isZaidsResortChosenForLuxuryClones ? 0 : -3;
            return _isZaidsResortChosenForLuxuryClones
                ? ""
                : "The Amazing Raze Resort was caught smuggling illegal drugs and providing prostitution services using Human Perfect's luxury clones." + _newLines;
        }

        private string GenerateHumanPerfectFooter()
        {
            if (_humanPerfectScore >= 3)
                return "Human Perfect dominates the cloning market and has began expanding into the medical market.";
            if (_humanPerfectScore >= 0)
                return "Despite Human Perfect's recent turmoil, their stocks are on the rise.";
            if (_humanPerfectScore >= -6)
                return "Human Perfect is no longer the leader in cloning, but they manage to hold a strong market share.";
            if (_humanPerfectScore >= -11)
                return "With Human Perfect's recent decline the shareholders have sold out to Mirror Mirror Corp.";
            return "Human Perfect declares BANKRUPTCY!";
        }

        public void Dispose()
        {
            _clickUI.Dispose();
        }
    }
}
