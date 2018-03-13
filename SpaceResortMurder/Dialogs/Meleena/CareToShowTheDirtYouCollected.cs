using SpaceResortMurder.Clues.MeleenasSpaceCraft;

namespace SpaceResortMurder.Dialogs.Meleena
{
    public class CareToShowTheDirtYouCollected : Dialog
    {
        public CareToShowTheDirtYouCollected() : base(nameof(CareToShowTheDirtYouCollected)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(DataStick))
                   && GameState.Instance.IsThinking(nameof(ImOnlyInvestigatingTheMurder));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
