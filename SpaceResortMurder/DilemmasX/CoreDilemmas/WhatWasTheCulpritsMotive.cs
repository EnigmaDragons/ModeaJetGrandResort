using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.TheCulpritsMotive;
using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX.CoreDilemmas
{
    public class WhatWasTheCulpritsMotive : Dilemma
    {
        public WhatWasTheCulpritsMotive() : base(new Vector2(990, 348), nameof(WhatWasTheCulpritsMotive), 
            new MeleenaGotCaught(),
            new MeleenaKilledHimBecauseHeIsEvil(),
            new RaymondsCloneWasDesignedToKillForRevenge(),
            new RevengeForHisBrothersDeath(),
            new ToReplaceRaymondAsCEO(),
            new ToSaveHisResort(),
            new RaymondsCloneWasDesignedToKillAndThenControlHumanPerfectByProxy()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeleenaWasTheCulprit))
                   || CurrentGameState.IsThinking(nameof(ZaidWasTheCulprit))
                   || CurrentGameState.IsThinking(nameof(TravisWasTheCulprit))
                   || CurrentGameState.IsThinking(nameof(RaymondsCloneWasTheCulprit))
                   || CurrentGameState.IsThinking(nameof(TravisAndRaymondsCloneAreTheCulprits));
        }
    }
}
