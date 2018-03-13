using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Clues.DockingBay;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoHackedTheDoor : Dilemma
    {
        public WhoHackedTheDoor() : base(new Vector2(900, 200), nameof(WhoHackedTheDoor), 
            new ZaidHackedTheDoor(),
            new TravisHackedTheDoor(),
            new MeleenaHackedTheDoor())
        {
        }

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(RaymondsShip));
        }
    }
}
