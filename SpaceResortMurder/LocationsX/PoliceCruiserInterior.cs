using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.PoliceSpaceCraft;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class PoliceCruiserInterior : Location
    {
        public PoliceCruiserInterior() : base(nameof(PoliceCruiserInterior),
            "Police Cruiser", 
            "Locations/PoliceCruiserPainted",
            new List<Clue>
            {
                new Clock(new Transform2(new Vector2(1370, 332), new Size2(140, 140)))
            }, 
            new List<IPathway>
            {
                new PoliceCruiserToDockingBay(new Transform2(new Vector2(411, 180), new Size2(913, 449)))
            }) {}
    }
}
