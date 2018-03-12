using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.CauseOfDeath;
using SpaceResortMurder.Deductions.EnteredSpaceFrom;

namespace SpaceResortMurder.DilemmasX
{
    public class WhereDidHeEnterSpaceFrom : Dilemma
    {
        public WhereDidHeEnterSpaceFrom() : base(new Vector2(700, 150), nameof(WhereDidHeEnterSpaceFrom), 
            new CameFromHisShip(),
            new CameFromtheGarbageAirlock()) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(LackOfOxygenInSpace));
        }
    }
}
