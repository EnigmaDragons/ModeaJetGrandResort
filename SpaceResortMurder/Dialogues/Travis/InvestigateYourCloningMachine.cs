namespace SpaceResortMurder.Dialogues.Travis
{
    public class InvestigateYourCloningMachine : Dialogue
    {
        public InvestigateYourCloningMachine() : base(nameof(InvestigateYourCloningMachine)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(TravissAccount));
        }
    }
}
