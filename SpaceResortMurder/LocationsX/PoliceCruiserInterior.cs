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
        public PoliceCruiserInterior() : base(nameof(PoliceCruiserInterior), "Police Cruiser", 
            new List<Clue>
            {
                new Clock(new Transform2(new Vector2(1300, 300), new Size2(180, 180)))
            }, 
            new List<IPathway>
            {
                new PoliceCruiserToDockingBay(new Transform2(new Vector2(750, 270), new Size2(203, 292)))
            }) {}
    }
}
