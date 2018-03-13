using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class InvestigateYourCloningMachine : Dialogue
    {
        public InvestigateYourCloningMachine() : base(nameof(InvestigateYourCloningMachine)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(TravissAccount));
        }
    }
}
