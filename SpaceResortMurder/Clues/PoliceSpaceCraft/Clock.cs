﻿using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Clues.PoliceSpaceCraft
{
    public class Clock : Clue
    {
        public Clock() : base(
            "Placeholder/clock",
            new Transform2(new Vector2(750, 300), new Size2(100, 100)),
            new Size2(300, 300),
            nameof(Clock))
        {
            IsActive = () => CurrentGameState.Instance.IsThinking(nameof(PettyTheftAt12));
        }
    }
}