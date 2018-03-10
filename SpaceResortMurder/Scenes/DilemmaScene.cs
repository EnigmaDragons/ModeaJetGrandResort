using System;
using System.Collections.Generic;
using MonoDragons.Core.Common;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.DilemmaStuff;
using MonoDragons.Core.PhysicsEngine;
using Microsoft.Xna.Framework;

namespace SpaceResortMurder.Scenes
{
    public class DilemmaScene : IScene
    {
        private ClickUI _clickUi;
        private IReadOnlyList<Dilemma> _dilemmas;
        private TextButton _return;

        public void Init()
        {
            _clickUi = new ClickUI();
            _dilemmas = GameObjects.Dilemmas.GetActiveDilemmas();
            _dilemmas.ForEach(x => _clickUi.Add(x.Button));
            _return = new TextButton(new Rectangle(1250, 750, 200, 100), () => Scene.NavigateTo(GameState.Instance.CurrentLocation), "Return",
                Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            _clickUi.Add(_return);
        }

        public void Update(TimeSpan delta)
        {
            _clickUi.Update(delta);
        }

        public void Draw()
        {
            _dilemmas.ForEach(x =>
            {
                x.Draw();
                x.DrawNewAnswersIfApplicable();
                x.DrawNewIfApplicable();
            });
            _return.Draw(Transform2.Zero);
        }
    }
}
