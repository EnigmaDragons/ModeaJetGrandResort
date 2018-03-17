using SpaceResortMurder.Deductions.BruisesCameFrom;
using SpaceResortMurder.Deductions.ClonesDesign;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class YourBeingRidiculous : Dialogue
    {
        public YourBeingRidiculous() : base(nameof(YourBeingRidiculous)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(BruisesCameFromAStruggle))
                && CurrentGameState.IsThinking(nameof(DesignedToKill));
        }
    }
}
