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
using SpaceResortMurder.Dialogs;

namespace SpaceResortMurder.LocationsX
{
    public abstract class LocationScene : IScene
    { 
        private readonly string _location;

        private ClickUI _clickUI;
        private List<IVisual> _dialogOptions = new List<IVisual>();
        private TextButton _backButton;
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

        protected abstract void OnInit();

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
            _backButton = new TextButton(new Rectangle(0, 800, 150, 50), StopTalking, "Back", Color.OrangeRed, Color.Red, Color.DarkRed, () => _isTalking);

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
            _visuals.ForEach(x => x.Draw(Transform2.Zero));
            if (_isTalking)
                _talkingTo.DrawTalking();
            if (!_isInTheMiddleOfDialog)
            {
                _dialogOptions.ForEach(x => x.Draw(Transform2.Zero));
                _backButton.Draw(Transform2.Zero);
            }
            if (!_isTalking && !_isInvestigating)
            {
                GameObjects.Hud.Draw();
                GameObjects.Hud.DrawNewIconsIfApplicable();
                _peopleHere.ForEach(p => p.DrawNewIconIfApplicable());
            }
            if (_isInvestigating)
                _investigatingThis.FacingImage.Draw(Transform2.Zero);
            if (_isInTheMiddleOfDialog)
                _reader.Draw();
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
            _characterTalkingToBranch = new ClickUIBranch("Dialog Choices", 1);
            var activeDialogs = character.GetDialogs();
            activeDialogs.ForEachIndex((x, i) =>
            {
                var itemCount = activeDialogs.Count;
                var verticalOffset = ((900 / (itemCount + 1)) * (i + 1)) - (((itemCount - i) / (itemCount + 1)) * 30);
                var button = x.CreateButton(HaveDialog, verticalOffset);
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
