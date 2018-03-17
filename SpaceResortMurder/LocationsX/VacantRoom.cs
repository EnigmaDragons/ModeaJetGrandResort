using SpaceResortMurder.Clues;
using SpaceResortMurder.Pathways;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues.VacantRoom;

namespace SpaceResortMurder.LocationsX
{
    public class VacantRoom : Location
    {
        public VacantRoom() : base(
            nameof(VacantRoom), 
            "Vacant Resort Room", 
            "Locations/hotelroom_environment",
            new List<Clue>
            {
                new T71EnergyBlaster(new Transform2(new Vector2(500, 650), new Size2(330, 330)))
            }, 
            new List<IPathway>
            {
                new VacantRoomToLobby(new Transform2(new Vector2(0, 134), new Size2(399, 876)))
            }) {}
    }
}