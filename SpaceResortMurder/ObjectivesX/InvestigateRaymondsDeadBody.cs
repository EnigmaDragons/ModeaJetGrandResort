using SpaceResortMurder.Dialogs;

namespace SpaceResortMurder.ObjectivesX
{
    public class InvestigateRaymondsDeadBody : Objective
    {
        public InvestigateRaymondsDeadBody() : base(nameof(InvestigateRaymondsDeadBody)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
