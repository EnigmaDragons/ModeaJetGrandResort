using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.CloningRoom;
using SpaceResortMurder.Pathways;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.LocationsX
{
    public sealed class TravissCloningRoom : Location
    {
        public TravissCloningRoom() : base(
            nameof(TravissCloningRoom), 
            "Travis's Cloning Room", 
            "Locations/researcher_room_final",
            new List<Clue>
            {
                new CloningChamber(new Transform2(new Vector2(152, 104), new Size2(577, 759)))
            }, 
            new List<IPathway>
            {
                new CloningRoomToLobby(new Transform2(new Vector2(30, 960), new Size2(96, 96)), "L")
            }) {}
    }
}