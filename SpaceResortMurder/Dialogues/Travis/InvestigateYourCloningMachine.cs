using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class InvestigateYourCloningMachine : Dialogue
    {
        public InvestigateYourCloningMachine() : base(nameof(InvestigateYourCloningMachine)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(TravissAccount));
        }
    }
}
