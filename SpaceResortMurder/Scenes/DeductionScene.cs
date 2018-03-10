using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Deductions;
using System;
using System.Collections.Generic;

namespace SpaceResortMurder.Scenes
{
    public class DeductionScene : IScene
    {
        private ClickUI _clickUI;
        private readonly string _dilemmaText;
        private Label _dilemmaLabel;
        private IReadOnlyList<Deduction> _deductions;
        private TextButton _return;

        public DeductionScene(string dilemma, IReadOnlyList<Deduction> deductions)
        {
            _dilemmaText = dilemma;
            _deductions = deductions;
        }

        public void Draw()
        {
            _return.Draw(Transform2.Zero);
            _dilemmaLabel.Draw(Transform2.Zero);
            _deductions.ForEach(d =>
            {
                d.Draw();
                d.DrawNewIfApplicable();
            });
        }

        public void Init()
        {
            _clickUI = new ClickUI();
            _dilemmaLabel = new Label()
            {
                Transform = new Transform2(new Size2(1600, 100)),
                BackgroundColor = Color.Transparent,
                Text = _dilemmaText,
                TextColor = Color.White
            };
            _deductions.ForEach(d => _clickUI.Add(d.Button));
            _return = new TextButton(new Rectangle(1250, 750, 200, 100), () => Scene.NavigateTo("Dilemmas"), "Return",
                Color.Red, new Color(175, 0, 0), new Color(95, 0, 0));
            _clickUI.Add(_return);
        }

        public void Update(TimeSpan delta)
        {
            _clickUI.Update(delta);
        }
    }
}
