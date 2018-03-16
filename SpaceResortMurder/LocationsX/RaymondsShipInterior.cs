using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Pathways;
using System.Collections.Generic;

namespace SpaceResortMurder.LocationsX
{
    public class RaymondsShipInterior : Location
    {
        public RaymondsShipInterior() : base(nameof(RaymondsShipInterior),
            "Raymond's Space Craft",
            "Locations/Raymond_final_bg",
            new List<Clue>
            {
                new RaymondsCorpse(new Transform2(new Vector2(690, 592), new Size2(370, 250))),
                new RaymondsPad(new Transform2(new Vector2(730, 810), new Size2(121, 80))),
                new ShipsLogs(new Transform2(new Vector2(1181, 108), new Size2(189, 209))),
            },
            new List<IPathway> { new RaymondsShipToDockingBay(new Transform2(new Vector2(151, 58), new Size2(472, 901))) })
        { }
    }
}
