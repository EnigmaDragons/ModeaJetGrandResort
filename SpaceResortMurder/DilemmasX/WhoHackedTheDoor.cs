using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoHackedTheDoor : Dilemma
    {
        public WhoHackedTheDoor() : base(new Vector2(990, 558), nameof(WhoHackedTheDoor), 
            new ZaidHackedTheDoor(),
            new TravisHackedTheDoor(),
            new MeleenaHackedTheDoor()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsShip));
        }
    }
}
