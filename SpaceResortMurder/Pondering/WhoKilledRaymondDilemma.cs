using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Pondering
{
    public class WhoKilledRaymondDilemma : IDilemma
    {
        private readonly TextButton _dilemmaButton;
        public ClickableUIElement Button => _dilemmaButton;

        public WhoKilledRaymondDilemma()
        {
            _dilemmaButton = new TextButton(new Rectangle(320, 400, 200, 25), () => {}, "Who killed Raymond?", Color.Blue, Color.AliceBlue, Color.Aqua);
        }

        public void Init()
        {
            Event.Publish(new DilemmaGained(this));
        }

        public void Draw()
        {
            _dilemmaButton.Draw(Transform2.Zero);
        }
    }
}
