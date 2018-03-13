using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.TheCulpritsMotive;
using SpaceResortMurder.Deductions.TheMurdererWas;

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
            return GameState.Instance.IsThinking(nameof(MeleenaWasTheCulprit))
                   || GameState.Instance.IsThinking(nameof(ZaidWasTheCulprit))
                   || GameState.Instance.IsThinking(nameof(TravisWasTheCulprit))
                   || GameState.Instance.IsThinking(nameof(RaymondsCloneWasTheCulprit))
                   || GameState.Instance.IsThinking(nameof(TravisAndRaymondsCloneAreTheCulprits));
        }
    }
}
