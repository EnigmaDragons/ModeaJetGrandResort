using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.Scenes;
using System.Collections.Generic;
using System.Linq;

namespace SpaceResortMurder.DilemmaStuff
{
    public abstract class Dilemma
    {
        private readonly TextButton _button;
        public ClickableUIElement Button => _button;

        public Dilemma(string dilemmaText, Transform2 transform, IReadOnlyList<Deduction> deductions)
        {
            _button = new TextButton(transform.ToRectangle(),
                () => Scene.NavigateTo(new DeductionScene(dilemmaText, deductions.Where(x => x.IsActive()).ToList())),
                dilemmaText,
                Color.Blue, Color.AliceBlue, Color.Aqua);
        }

        public abstract bool IsActive();

        public void Draw()
        {
            _button.Draw(Transform2.Zero);
        }
    }
}