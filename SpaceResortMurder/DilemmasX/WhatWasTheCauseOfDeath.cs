using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions.CauseOfDeath;

namespace SpaceResortMurder.DilemmasX
{
    public class WhatWasTheCauseOfDeath : Dilemma
    {
        public WhatWasTheCauseOfDeath() : base(new Vector2(1300, 500), nameof(WhatWasTheCauseOfDeath), 
            new LackOfOxygenInSpace(),
            new PoisonNeedles(),
            new ChokedBySomeone()) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(RaymondsCorpse));
        }
    }
}
