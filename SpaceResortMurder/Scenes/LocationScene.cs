using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Characters;
using MonoDragons.Core.Inputs;

namespace SpaceResortMurder.Scenes
{
    public abstract class LocationScene : IScene
    {
        protected ClickUI _clickUI;
        private List<Action> _drawActions = new List<Action>();
        protected ClickUIBranch _investigateRoomBranch;
        protected bool _isInTheMiddleOfDialog = false;

        protected LocationScene(string location)
        {
            GameState.Instance.CurrentLocation = location;
            _clickUI = new ClickUI();
            _investigateRoomBranch = new ClickUIBranch("Location Investigation", 1);
            _clickUI.Add(_investigateRoomBranch);
        }

        public abstract void Init();

        public abstract void Update(TimeSpan delta);

        public abstract void Draw();

        protected void DrawDialogs()
        {
            _drawActions.ForEach(x => x());
        }

        protected void TalkTo(Person person)
        {
            _clickUI.Remove(_investigateRoomBranch);
            var drawDialogsOptions = new List<Action>();
            var dialogOptionsBranch = new ClickUIBranch("Dialog Choices", 1);
            var activeDialogs = person.GetDialogs();
            activeDialogs.ForEachIndex((x, i) =>
            {
                dialogOptionsBranch.Add(x.Button);
                var itemCount = activeDialogs.Count;
                var verticalOffset = ((900 / (itemCount + 1)) * (i + 1)) - (((itemCount - i) / (itemCount + 1)) * 30);
                x.Button.Offset = new Vector2(0, verticalOffset);
                drawDialogsOptions.Add(() => x.Draw(new Transform2(new Vector2(0, verticalOffset))));
            });
            _drawActions = drawDialogsOptions;
            _clickUI.Add(dialogOptionsBranch);
        }
    }
}
