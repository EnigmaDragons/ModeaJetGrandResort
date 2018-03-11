using SpaceResortMurder.DilemmaStuff;

namespace SpaceResortMurder.ObjectiveStuff
{
    public class InvestigateRaymondsDeadBody : Objective
    {
        public InvestigateRaymondsDeadBody() 
            : base("Investigate Raymond's dead body", "Raymond was found dead on his personal space craft at around 8 PM last night") {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(WhoKilledRaymond));
        }
    }
}
