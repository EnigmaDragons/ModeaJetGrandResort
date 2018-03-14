using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions.ZaidsResortForBetaTesting;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WasZaidsResortAcceptedAsABetaTester : Dilemma
    {
        public WasZaidsResortAcceptedAsABetaTester() : base(new Vector2(150, 768), nameof(WasZaidsResortAcceptedAsABetaTester), 
            new ZaidsResortAccepted(),
            new ZaidsResortDeclined()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsPad));
        }
    }
}
