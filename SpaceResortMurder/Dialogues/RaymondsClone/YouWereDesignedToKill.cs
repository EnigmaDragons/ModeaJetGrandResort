using SpaceResortMurder.Deductions.ClonesDesign;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class YouWereDesignedToKill : Dialogue
    {
        public YouWereDesignedToKill() : base(nameof(YouWereDesignedToKill)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(DesignedToKill));
        }
    }
}
