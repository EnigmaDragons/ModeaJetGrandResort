using SpaceResortMurder.Dialogs.Warren;

namespace SpaceResortMurder.Dialogs.Meleena
{
    public class HereIsTheSearchOrder : Dialog
    {
        public HereIsTheSearchOrder() : base(nameof(HereIsTheSearchOrder)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(INeedASearchOrder))
                   && !GameState.Instance.IsThinking(nameof(ImOnlyInvestigatingTheMurder));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
