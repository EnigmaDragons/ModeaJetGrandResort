using SpaceResortMurder.Deductions.BruisesCameFrom;
using SpaceResortMurder.Deductions.ClonesDesign;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class YouWereDesignedToKill : Dialogue
    {
        public YouWereDesignedToKill() : base(nameof(YouWereDesignedToKill)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(DesignedToKill))
                && CurrentGameState.IsThinking(nameof(FoundYouRaymondsClone))
                && !(CurrentGameState.IsThinking(nameof(BruisesCameFromAStruggle))
                    && CurrentGameState.IsThinking(nameof(DesignedToKill)));
        }
    }
}
