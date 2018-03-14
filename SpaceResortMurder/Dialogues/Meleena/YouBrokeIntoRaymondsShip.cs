﻿using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class YouBrokeIntoRaymondsShip : Dialogue
    {
        public YouBrokeIntoRaymondsShip() : base(nameof(YouBrokeIntoRaymondsShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(SkeletonKey))
                   && CurrentGameState.Instance.IsThinking(nameof(MeleenaHackedTheDoor));
        }
    }
}