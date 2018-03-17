using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoWasTheMurderer : Dilemma
    {
        public WhoWasTheMurderer() : base(new Vector2(795, 473), nameof(WhoWasTheMurderer), 
            new ZaidWasTheCulprit(),
            new MeleenaWasTheCulprit(),
            new TravisWasTheCulprit(),
            new RaymondsCloneWasTheCulprit(),
            new TravisAndRaymondsCloneAreTheCulprits()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WarrenIntroduction));
        }
    }
}
