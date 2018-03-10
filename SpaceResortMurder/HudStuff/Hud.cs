using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.HudStuff
{
    public class Hud
    {
        private TextButton _navigateToDilemma;

        public ClickUIBranch HudBranch { get; private set; }

        public void Init()
        {
            _navigateToDilemma = new TextButton(new Rectangle(1500, 0, 120, 120), () => Scene.NavigateTo(GameObjects.DilemmasSceneName), "Dilemmas",
                Color.Green, Color.GreenYellow, Color.LightGreen);
            HudBranch = new ClickUIBranch("HUD", 2);
            HudBranch.Add(_navigateToDilemma);
        }

        public void Draw()
        {
            _navigateToDilemma.Draw(Transform2.Zero);
        }
    }
}
