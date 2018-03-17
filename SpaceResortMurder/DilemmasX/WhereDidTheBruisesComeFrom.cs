using Microsoft.Xna.Framework;
using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Deductions.BruisesCameFrom;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhereDidTheBruisesComeFrom : Dilemma
    {
        public WhereDidTheBruisesComeFrom() : base(new Vector2(1490, 353), nameof(WhereDidTheBruisesComeFrom), 
            new BruisesCameFromAStruggle(),
            new BruisesCameFromMatterRemoval()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(CEORaymondsClone));
        }
    }
}
