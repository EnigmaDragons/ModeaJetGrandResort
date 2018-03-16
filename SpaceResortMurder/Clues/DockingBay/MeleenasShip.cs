using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.DockingBay
{
    public class MeleenasShip : Clue
    {
        public MeleenasShip() : base(
            "Placeholder/MeleenasShip", 
            new Transform2(new Vector2(1000, 500), new Size2(290, 140)), 
            new Size2(580, 280), 
            nameof(MeleenasShip),
            "") {}
    }
}
