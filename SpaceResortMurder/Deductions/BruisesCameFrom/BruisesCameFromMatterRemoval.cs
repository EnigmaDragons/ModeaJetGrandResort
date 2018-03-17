using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.BruisesCameFrom
{
    public class BruisesCameFromMatterRemoval : Deduction
    {
        public BruisesCameFromMatterRemoval() : base(nameof(BruisesCameFromMatterRemoval)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(Bruises));
        }
    }
}
