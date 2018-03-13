using SpaceResortMurder.Dialogues.RaymondsClone;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class RaymondsCloneWasTheCulprit : Deduction
    {
        public RaymondsCloneWasTheCulprit() : base(nameof(RaymondsCloneWasTheCulprit)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingRaymondsClone));
        }
    }
}
