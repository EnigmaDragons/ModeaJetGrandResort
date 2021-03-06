﻿using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions.ZaidsResortForBetaTesting;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WasZaidsResortAcceptedAsABetaTester : Dilemma
    {
        public WasZaidsResortAcceptedAsABetaTester() : base(new Vector2(100, 353), nameof(WasZaidsResortAcceptedAsABetaTester), 
            new ZaidsResortAccepted(),
            new ZaidsResortDeclined()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsPad)) && CurrentGameState.IsThinking(nameof(DidRaymondApproveYourResort));
        }
    }
}
