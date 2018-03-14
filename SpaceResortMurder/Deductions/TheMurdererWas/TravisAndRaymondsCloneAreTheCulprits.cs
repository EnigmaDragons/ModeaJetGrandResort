﻿using SpaceResortMurder.Deductions.ClonesDesign;
using SpaceResortMurder.Deductions.VictimsIdentity;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class TravisAndRaymondsCloneAreTheCulprits : Deduction
    {
        public TravisAndRaymondsCloneAreTheCulprits() : base(nameof(TravisAndRaymondsCloneAreTheCulprits)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(TheVictimIsRaymond)) 
                && CurrentGameState.IsThinking(nameof(ViolentExperimentalResearch))
                && CurrentGameState.IsThinking(nameof(DesignedToKill));
        }
    }
}
