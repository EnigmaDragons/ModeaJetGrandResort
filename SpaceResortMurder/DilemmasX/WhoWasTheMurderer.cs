using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Dialogs.Zaid;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoWasTheMurderer : Dilemma
    {
        public WhoWasTheMurderer() : base(new Vector2(620, 390), nameof(WhoWasTheMurderer), 
            new ZaidKilledForHisResort()) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(YouWereNotAcceptedForBetaTesting));
        }
    }
}
