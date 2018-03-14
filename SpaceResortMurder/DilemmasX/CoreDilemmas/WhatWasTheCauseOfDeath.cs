using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions.CauseOfDeath;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhatWasTheCauseOfDeath : Dilemma
    {
        public WhatWasTheCauseOfDeath() : base(new Vector2(250, 348), nameof(WhatWasTheCauseOfDeath),
            new PushedOutOfHisShip(),
            new ChokedBySomeone(),
            new PoisonNeedles(),
            new LaunchedIntoSpaceFromTheGarbageAirlock()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsCorpse));
        }
    }
}
