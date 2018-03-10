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
using SpaceResortMurder.Characters;

namespace SpaceResortMurder.Scenes
{
    public abstract class LocationScene : IScene
    {
        private readonly ClickUI _clickUI;

        private List<Action> _drawDialogOptions = new List<Action>();
        private readonly TextButton _backButton;
        private bool _isInTheMiddleOfDialog = false;
        private ClickUIBranch _characterTalkingToBranch;
        private Person _talkingTo;
        private bool _isTalking;

        protected ClickUIBranch _investigateRoomBranch;
        protected List<IVisual> _visuals = new List<IVisual>();

        protected LocationScene(string location)
        {
            GameState.Instance.CurrentLocation = location;

            _investigateRoomBranch = new ClickUIBranch("Location Investigation", 1);

            var peopleHere = GameObjects.People.GetPeopleAt(location);
            var characterButtons = peopleHere.Select(x => new ImageButton(x.Image, x.Image, x.Image, x.WhereAreYouStanding(), 
                () => TalkTo(x), 
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
            Input.On(Control.Select, () => { if (!_isInTheMiddleOfDialog) Scene.NavigateTo(GameObjects.OptionsSceneName); });
            Input.On(Control.X, () => { if (!_isInTheMiddleOfDialog) Scene.NavigateTo(GameObjects.DilemmasSceneName); });
        }

        public abstract void Init();

        public void Update(TimeSpan delta)
        {
            _clickUI.Update(delta);
        }

        public void Draw()
        {
            _visuals.ForEach(x => x.Draw(Transform2.Zero));
            _drawDialogOptions.ForEach(x => x());
            _backButton.Draw(Transform2.Zero);
            if (!_isTalking)
                GameObjects.Hud.Draw();

        }

        private void TalkTo(Person person)
        {
            _clickUI.Remove(_investigateRoomBranch);
            var drawDialogsOptions = new List<Action>();
            _characterTalkingToBranch = new ClickUIBranch("Dialog Choices", 1);
            var activeDialogs = person.GetDialogs();
            activeDialogs.ForEachIndex((x, i) =>
            {
                _characterTalkingToBranch.Add(x.Button);
                var itemCount = activeDialogs.Count;
                var verticalOffset = ((900 / (itemCount + 1)) * (i + 1)) - (((itemCount - i) / (itemCount + 1)) * 30);
                x.Button.Offset = new Vector2(0, verticalOffset);
                drawDialogsOptions.Add(() => x.Draw(new Transform2(new Vector2(0, verticalOffset))));
            });
            _characterTalkingToBranch.Add(_backButton);
            _drawDialogOptions = drawDialogsOptions;
            _clickUI.Add(_characterTalkingToBranch);
            _talkingTo = person;
            _isTalking = true;
        }

        private void StopTalking()
        {
            _isTalking = false;
            _clickUI.Remove(_characterTalkingToBranch);
            _drawDialogOptions = new List<Action>();
            _clickUI.Add(_investigateRoomBranch);
        }
    }
}
