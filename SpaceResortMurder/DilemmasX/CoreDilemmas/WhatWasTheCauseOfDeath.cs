using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions.CauseOfDeath;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhatWasTheCauseOfDeath : Dilemma
    {
        public WhatWasTheCauseOfDeath() : base(new Vector2(460, 473), nameof(WhatWasTheCauseOfDeath),
            new PushedOutOfHisShip(),
            new ChokedBySomeone(),
            new KilledInSpace(),
            new LaunchedIntoSpaceFromTheGarbageAirlock()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsCorpse));
        }
    }
}
