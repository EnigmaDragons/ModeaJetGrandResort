using SpaceResortMurder.Dialogues.Warren;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class HereIsTheSearchOrder : Dialogue
    {
        public HereIsTheSearchOrder() : base(nameof(HereIsTheSearchOrder)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(NeedASearchOrder))
                   && !GameState.Instance.IsThinking(nameof(ImOnlyInvestigatingTheMurder));
        }
    }
}
