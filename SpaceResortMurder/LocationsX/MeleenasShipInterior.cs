﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public class MeleenasShipInterior : Location
    {
        public MeleenasShipInterior() : base(nameof(MeleenasShipInterior), "Meleena's Space Craft", 
            new List<Clue>
            {
                new EncryptedDataStick(),
                new UnencryptedDataDrive(),
                new SkeletonKey(new Transform2(new Vector2(444, 765), new Size2(154, 104))),
                new HackingRig(new Transform2(new Vector2(514, 169), new Size2(331, 331))),
            }, 
            new List<IPathway>
            {
                new MeleenasShipToDockingBay(new Transform2(new Vector2(1764, 950), new Size2(96, 96)))
            }) {}
    }
}