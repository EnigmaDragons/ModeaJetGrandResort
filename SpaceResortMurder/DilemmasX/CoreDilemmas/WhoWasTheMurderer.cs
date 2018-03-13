using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.MeleenasAccountValidity;
using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoWasTheMurderer : Dilemma
    {
        public WhoWasTheMurderer() : base(new Vector2(620, 300), nameof(WhoWasTheMurderer), 
            new ZaidWasTheCulprit(),
            new MeleenaWasTheCulprit(),
            new TravisWasTheCulprit(),
            new RaymondsCloneWasTheCulprit(),
            new TravisAndRaymondsCloneAreTheCulprits()) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(YouWereNotAcceptedForBetaTesting))
                || CurrentGameState.Instance.IsThinking(nameof(MeleenaIsLying))
                || CurrentGameState.Instance.IsThinking(nameof(MeetingRaymondsClone));
        }
    }
}
