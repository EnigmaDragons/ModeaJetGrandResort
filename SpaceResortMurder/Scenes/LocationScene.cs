using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Characters;
using SpaceResortMurder.Dialogs;

namespace SpaceResortMurder.Scenes
{
    public abstract class LocationScene : IScene
    { 
        private readonly string _location;

        private ClickUI _clickUI;
        private List<IVisual> _dialogOptions = new List<IVisual>();
        private TextButton _backButton;
        private bool _isInTheMiddleOfDialog = false;
        private ClickUIBranch _characterTalkingToBranch;
        private Person _talkingTo;
        private bool _isTalking;
        private Reader _reader;

        protected ClickUIBranch _investigateRoomBranch;
        protected List<IVisual> _visuals = new List<IVisual>();

        protected LocationScene(string location)
        {
            _location = location;

        }

        public abstract void Init();

        public void InitBase()
        {
            GameState.Instance.CurrentLocation = _location;

            _investigateRoomBranch = new ClickUIBranch("Location Investigation", 1);

            var peopleHere = GameObjects.People.GetPeopleAt(_location);
            var characterButtons = peopleHere.Select(x => new ImageButton(x.Image, x.Image, x.Image, x.WhereAreYouStanding(),
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
            if (!_isTalking)
                GameObjects.Hud.Draw();
            if (_isInTheMiddleOfDialog)
                _reader.Draw();

        }

        private void TalkTo(Person person)
        {
            var drawDialogsOptions = new List<IVisual>();
            _characterTalkingToBranch = new ClickUIBranch("Dialog Choices", 1);
            var activeDialogs = person.GetDialogs();
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
            _talkingTo = person;
            _isTalking = true;
        }

        private void StopTalking()
        {
            _isTalking = false;
            _clickUI.Remove(_characterTalkingToBranch);
            _dialogOptions = new List<IVisual>();
            _clickUI.Add(_investigateRoomBranch);
        }

        private void HaveDialog(List<string> lines)
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
    }
}
