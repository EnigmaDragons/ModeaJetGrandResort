using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Characters;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Scenes;

namespace SpaceResortMurder.Scenes
{
    public class BlackRoomScene : LocationScene
    {
        private bool _isTalkingToCop = false;
        private ImageButton _chillinBackCop;
        private ImageBox _talkingCop;

        public BlackRoomScene() : base("Black Room") {}

        public override void Init()
        {
            Input.ClearTransientBindings();
            Input.On(Control.Select, () => { if (!_isInTheMiddleOfDialog) Scene.NavigateTo(GameObjects.OptionsSceneName); });
            Input.On(Control.X, () => { if (!_isInTheMiddleOfDialog) Scene.NavigateTo(GameObjects.DilemmasSceneName); });
            _chillinBackCop = new ImageButton("Characters/policeman", "Characters/policeman", "Characters/policeman",
                new Transform2(new Vector2(200, 200), new Size2(200, 470)), () =>
                {
                    _isTalkingToCop = true;
                    TalkTo(new PoliceOfficier());
                }, () => !_isTalkingToCop);
            _investigateRoomBranch.Add(_chillinBackCop);
            _talkingCop = new ImageBox(new Transform2(new Vector2(650, 200), new Size2(300, 705)), "Characters/policeman");
        }

        public override void Update(TimeSpan delta)
        {
            _clickUI.Update(delta);
        }

        public override void Draw()
        {
            if (_isTalkingToCop)
            {
                _talkingCop.Draw(Transform2.Zero);
                DrawDialogs();
            }
            else
            {
                _chillinBackCop.Draw(Transform2.Zero);
                DrawHud();
            }
        }
    }
}
