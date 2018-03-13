using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Dialogues;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.LocationsX
{
    public abstract class LocationScene : IScene
    { 
        private readonly string _location;

        private ClickUI _clickUI;
        private List<IVisual> _dialogOptions = new List<IVisual>();
        private VisualClickableUIElement _backButton;
        private IVisual _locationNameLabel;
        private bool _isInTheMiddleOfDialog = false;
        private ClickUIBranch _characterTalkingToBranch;
        private Character _talkingTo;
        private Clue _investigatingThis;
        private bool _isTalking;
        private Reader _reader;
        private bool _isInvestigating;
        private IReadOnlyList<Character> _peopleHere;

        protected ClickUIBranch _investigateRoomBranch;
        protected List<IVisual> _visuals = new List<IVisual>();

        protected abstract string Name { get; }
        protected abstract void OnInit();
        protected abstract void DrawBackground();

        protected LocationScene(string location)
        {
            _location = location;
        }

        public void Init()
        {
            GameObjects.InitIfNeeded();
            GameState.Instance.CurrentLocation = _location;

            _investigateRoomBranch = new ClickUIBranch("Location Investigation", 1);

            OnInit();
            _locationNameLabel = UiLabels.HeaderLabel(Name, Color.White);
            _peopleHere = GameObjects.Characters.GetPeopleAt(_location);
            var characterButtons = _peopleHere.Select(x => new ImageButton(x.Image, x.Image, x.Image, x.WhereAreYouStanding(),
                () =>
                {
                    _clickUI.Remove(_investigateRoomBranch);
                    TalkTo(x);
                },
                () => !(_isTalking && _talkingTo == x)));
            characterButtons.ForEach(x =>
            {
                _visuals.Add(x);
                _investigateRoomBranch.Add(x);
            });

            _clickUI = new ClickUI();
            _clickUI.Add(_investigateRoomBranch);
            _clickUI.Add(GameObjects.Hud.HudBranch);
            _backButton = new ImageTextButton(new Transform2(new Rectangle(-900, 800, 1380, 64)), StopTalking, "Thanks for your help.",
                "Convo/DialogueButton", "Convo/DialogueButton-Hover", "Convo/DialogueButton-Press", () => _isTalking)
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(50, 800), Rotation2.Default, new Size2(1380 - 900, 64), 1.0f),
                TextAlignment = HorizontalAlignment.Left
            };

            Input.ClearTransientBindings();
            Input.On(Control.Select, () => { if (!_isInTheMiddleOfDialog) Scene.NavigateTo(GameResources.OptionsSceneName); });
            Input.On(Control.X, () => { if (!_isInTheMiddleOfDialog) Scene.NavigateTo(GameResources.DilemmasSceneName); });

            if(_peopleHere.Any(p => p.IsImmediatelyTalking()))
            {
                var person = _peopleHere.First(p => p.IsImmediatelyTalking());
                _clickUI.Remove(_investigateRoomBranch);
                TalkTo(person);
                person.StartImmediatelyTalking((x) => HaveDialog(x));
            }
        }

        public void Update(TimeSpan delta)
        {
            if (_isInTheMiddleOfDialog)
                _reader.Update(delta);
            _clickUI.Update(delta);
        }

        public void Draw()
        {
            DrawBackground();
            _visuals.ForEach(x => x.Draw(Transform2.Zero));
            if (_isTalking)
            {
                _talkingTo.DrawTalking();
            }
            if (!_isInTheMiddleOfDialog)
            {
                _dialogOptions.ForEach(x => x.Draw(Transform2.Zero));
                _backButton.Draw(Transform2.Zero);
            }
            if (!_isTalking && !_isInvestigating)
            {
                GameObjects.Hud.Draw(Transform2.Zero);
                _peopleHere.ForEach(p => p.DrawNewIconIfApplicable());
            }
            if (_isInvestigating)
                _investigatingThis.FacingImage.Draw(Transform2.Zero);
            if (_isInTheMiddleOfDialog)
                _reader.Draw();

            UI.FillScreen("UI/ScreenOverlay-Purple");
            _locationNameLabel.Draw(Transform2.Zero);
        }

        protected void AddClue(Clue clue)
        {
            var button = clue.CreateButton(() => Investigate(clue));
            _visuals.Add(button);
            _investigateRoomBranch.Add(button);
        }

        private void TalkTo(Character character)
        {
            _clickUI.Remove(GameObjects.Hud.HudBranch);
            var drawDialogsOptions = new List<IVisual>();
            _characterTalkingToBranch = new ClickUIBranch("Dialogue Choices", 1);
            var activeDialogs = character.GetNewDialogs();
            activeDialogs.ForEachIndex((x, i) =>
            {
                var button = x.CreateButton(HaveDialog, i, activeDialogs.Count);
                _characterTalkingToBranch.Add(button);
                drawDialogsOptions.Add(button);
            });
            _characterTalkingToBranch.Add(_backButton);
            _dialogOptions = drawDialogsOptions;
            _clickUI.Add(_characterTalkingToBranch);
            _talkingTo = character;
            _isTalking = true;
        }

        private void StopTalking()
        {
            _isTalking = false;
            _clickUI.Remove(_characterTalkingToBranch);
            _dialogOptions = new List<IVisual>();
            _clickUI.Add(_investigateRoomBranch);
            _clickUI.Add(GameObjects.Hud.HudBranch);
        }

        private void HaveDialog(string[] lines)
        {
            _clickUI.Remove(_characterTalkingToBranch);
            _reader = new Reader(lines, EndDialog);
            _isInTheMiddleOfDialog = true;
        }

        private void EndDialog()
        {
            _isInTheMiddleOfDialog = false;
            TalkTo(_talkingTo);
        }

        private void Investigate(Clue clue)
        {
            _clickUI.Remove(_investigateRoomBranch);
            _reader = new Reader(clue.InvestigationLines, StopInvestigating);
            _investigatingThis = clue;
            _clickUI.Remove(GameObjects.Hud.HudBranch);
            _isInTheMiddleOfDialog = true;
            _isInvestigating = true;
        }

        private void StopInvestigating()
        {
            _clickUI.Add(_investigateRoomBranch);
            _clickUI.Add(GameObjects.Hud.HudBranch);
            _isInTheMiddleOfDialog = false;
            _isInvestigating = false;
        }

        public void Dispose()
        {
            _clickUI.Dispose();
        }
    }
}
