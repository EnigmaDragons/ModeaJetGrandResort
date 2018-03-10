using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Deductions
{
    public abstract class Deduction
    {
        private readonly TextButton _button;
        public ClickableUIElement Button => _button;

        public Deduction(string deductionText, Transform2 transform)
        {
            _button = new TextButton(transform.ToRectangle(), () => { }, deductionText, Color.Blue, Color.AliceBlue, Color.Aqua);
        }

        public abstract bool IsActive();

        public void Draw()
        {
            _button.Draw(Transform2.Zero);
        }
    }
}