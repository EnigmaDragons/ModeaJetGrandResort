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
            new RaymondWasDefendingHimself(),
            new RevengeForHisBrothersDeath(),
            new ToFrameRaymondAndMakeHimLookLikeAClone(),
            new ToReplaceRaymondAsCEO(),
            new ToSaveHisResort(),
            new RaymondsCloneWasDesignedToKillAndThenControlHumanPerfectByProxy()) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(MeleenaWasTheCulprit))
                   || CurrentGameState.Instance.IsThinking(nameof(ZaidWasTheCulprit))
                   || CurrentGameState.Instance.IsThinking(nameof(TravisWasTheCulprit))
                   || CurrentGameState.Instance.IsThinking(nameof(RaymondsCloneWasTheCulprit))
                   || CurrentGameState.Instance.IsThinking(nameof(TravisAndRaymondsCloneAreTheCulprits));
        }
    }
}
