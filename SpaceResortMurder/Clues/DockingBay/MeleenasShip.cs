using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Clues.DockingBay
{
    public class MeleenasShip : Clue
    {
        public MeleenasShip(Transform2 transform) : base(
            "Clues/MeleenasShip", 
            transform, 
            new Size2(451, 314), 
            nameof(MeleenasShip),
            "Modded Craft") {}
    }
}
