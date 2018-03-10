using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.DilemmaStuff
{
    public abstract class Dilemma
    {
        private readonly TextButton _button;
        private readonly Deduction[] _deductions;
        public ClickableUIElement Button => _button;

        public Dilemma(string dilemmaText, Transform2 transform, params Deduction[] deductions)
        {
            _deductions = deductions;
            _button = new TextButton(transform.ToRectangle(),
                () => Scene.NavigateTo(new DeductionScene(dilemmaText, _deductions.Where(x => x.IsActive()).ToList())),
                dilemmaText,
                Color.Blue, Color.AliceBlue, Color.Aqua);
            _deductions.ForEach(d => d.Init(ClearPriorDeductions,
                new Transform2(
                    new Vector2(transform.Location.X, transform.Location.Y + transform.Size.Height),
                    new Size2(transform.Size.Width, 100))));
        }

        public abstract bool IsActive();

        public void Draw()
        {
            _deductions.ForEach(x => x.DrawConclusionIfApplicable());
            _button.Draw(Transform2.Zero);
        }

        private void ClearPriorDeductions()
        {
            _deductions.ForEach(x => x.Reset());
        }
    }
}