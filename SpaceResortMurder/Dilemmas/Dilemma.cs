using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Pondering
{
    public abstract class Dilemma
    {
        private readonly TextButton _button;
        public ClickableUIElement Button => _button;

        public Dilemma(string dilemmaText, Transform2 transform)
        {
            _button = new TextButton(transform.ToRectangle(), () => { }, dilemmaText, Color.Blue, Color.AliceBlue, Color.Aqua);
        }

        public abstract bool IsActive();

        public void Draw()
        {
            _button.Draw(Transform2.Zero);
        }
    }
}