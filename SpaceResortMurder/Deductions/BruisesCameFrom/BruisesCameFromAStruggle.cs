using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.BruisesCameFrom
{
    public class BruisesCameFromAStruggle : Deduction
    {
        public BruisesCameFromAStruggle() : base(nameof(BruisesCameFromAStruggle)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MatterRemovalBruises));
        }
    }
}
