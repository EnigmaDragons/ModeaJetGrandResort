using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.CauseOfDeath;
using SpaceResortMurder.Deductions.EnteredSpaceFrom;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhereDidHeEnterSpaceFrom : Dilemma
    {
        public WhereDidHeEnterSpaceFrom() : base(new Vector2(700, 150), nameof(WhereDidHeEnterSpaceFrom), 
            new CameFromHisShip(),
            new CameFromtheGarbageAirlock()) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(LackOfOxygenInSpace));
        }
    }
}
