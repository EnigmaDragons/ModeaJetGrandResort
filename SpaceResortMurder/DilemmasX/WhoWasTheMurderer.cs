using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Dialogues.Zaid;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoWasTheMurderer : Dilemma
    {
        public WhoWasTheMurderer() : base(new Vector2(620, 390), nameof(WhoWasTheMurderer), 
            new ZaidKilledForHisResort(),
            new MeleenaKilledBecauseSheWasDiscovered(),
            new MeleenaKilledHimCauseHeIsCorrupt()) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(YouWereNotAcceptedForBetaTesting));
        }
    }
}
