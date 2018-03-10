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

        public DeductionScene(string dilemma, IReadOnlyList<Deduction> deductions)
        {
            _dilemmaText = dilemma;
            _deductions = deductions;
        }

        public void Draw()
        {
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
        }

        public void Update(TimeSpan delta)
        {
            _clickUI.Update(delta);
        }
    }
}
