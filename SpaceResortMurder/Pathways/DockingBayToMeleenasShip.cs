using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public sealed class DockingBayToMeleenasShip : TraverseArrowPathway
    {
        public DockingBayToMeleenasShip(Transform2 transform, string traverseArrowType)
            : base(transform, nameof(MeleenasShipInterior), "To Modded Craft", traverseArrowType) { }

        public override bool IsTraversible =>  CurrentGameState.IsThinking(nameof(HereIsTheSearchOrder));
    }
}
