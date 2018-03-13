using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class HereIsTheSearchOrder : Dialogue
    {
        public HereIsTheSearchOrder() : base(nameof(HereIsTheSearchOrder)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(NeedASearchOrder))
                   && !CurrentGameState.Instance.IsThinking(nameof(ImOnlyInvestigatingTheMurder));
        }
    }
}
