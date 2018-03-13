using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.MeleenasAccountValidity;
using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.Dialogues.Zaid;

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
            return GameState.Instance.IsThinking(nameof(YouWereNotAcceptedForBetaTesting))
                || GameState.Instance.IsThinking(nameof(MeleenaIsLying))
                || GameState.Instance.IsThinking(nameof(MeetingRaymondsClone));
        }
    }
}
