using SpaceResortMurder.Clues.MeleenasSpaceCraft;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class CareToShowTheDirtYouCollected : Dialogue
    {
        public CareToShowTheDirtYouCollected() : base(nameof(CareToShowTheDirtYouCollected)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(DataStick))
                   && GameState.Instance.IsThinking(nameof(ImOnlyInvestigatingTheMurder));
        }
    }
}
