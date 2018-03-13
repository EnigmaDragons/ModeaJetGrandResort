using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Dialogues.Warren;

namespace SpaceResortMurder.ObjectivesX
{
    public class InvestigateRaymondsDeadBody : Objective
    {
        public InvestigateRaymondsDeadBody() : base(nameof(InvestigateRaymondsDeadBody)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren)) 
                && !GameState.Instance.IsThinking(nameof(RaymondsCorpse));
        }
    }
}
