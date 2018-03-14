﻿using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.CloningRoom;
using SpaceResortMurder.Pathways;
using System.Collections.Generic;

namespace SpaceResortMurder.LocationsX
{
    public class TravissCloningRoom : Location
    {
        public TravissCloningRoom() : base(nameof(TravissCloningRoom), "Travis's Cloning Room", 
            new List<Clue> { new CloningChamber() }, 
            new List<Pathway> { new CloningRoomToLobby() }) {}
    }
}