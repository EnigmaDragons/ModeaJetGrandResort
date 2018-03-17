using Microsoft.Xna.Framework;
using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Deductions.ElectricalBurnsComeFrom;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhereDidRaymondsCloneGetAnElectricalBurn : Dilemma
    {
        public WhereDidRaymondsCloneGetAnElectricalBurn() : base(new Vector2(100, 593), nameof(WhereDidRaymondsCloneGetAnElectricalBurn), 
            new ACloningMalfunction(),
            new AStunGun(),
            new SomethingElse()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(CEORaymondsClone));
        }
    }
}
