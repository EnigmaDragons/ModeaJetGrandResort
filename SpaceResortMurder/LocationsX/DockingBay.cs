using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class DockingBay : Location
    {
        public DockingBay() : base(nameof(DockingBay), 
            "Docking Bay", 
            "Locations/Docking_bay_final",
            new List<Clue>
            {
                new PoliceCruiserShip(new Transform2(new Vector2(593, 644), new Size2(501, 288))),
                new RaymondsShip(new Transform2(new Vector2(1511, 405), new Size2(409, 523))),
                new MeleenasShip(new Transform2(new Vector2(1054, 609), new Size2(451, 314))),
                new GarbageAirlock(new Transform2(new Vector2(358, 614), new Size2(237, 182))),
            }, 
            new List<IPathway>
            {
                new DockingBayToLobby(new Transform2(new Vector2(0, 571), new Size2(287, 227))),
                new DockingBayToRaymondsShip(new Transform2(new Vector2(1670, 960), new Size2(96, 96)), "U"),
                new DockingBayToMeleenasShip(new Transform2(new Vector2(1190, 945), new Size2(96, 96)), "U"),
                new DockingBayToPoliceCruiser(new Transform2(new Vector2(740, 930), new Size2(96, 96)), "U"),
            }) {}
    }
}