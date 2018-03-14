using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class RaymondsCloneWasTheCulprit : Deduction
    {
        public RaymondsCloneWasTheCulprit() : base(nameof(RaymondsCloneWasTheCulprit)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeetingRaymondsClone));
        }
    }
}
