using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.TheMurdererWas;

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
            return true;
        }
    }
}
