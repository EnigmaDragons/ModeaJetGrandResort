using SpaceResortMurder.Clues.MeleenasSpaceCraft;

namespace SpaceResortMurder.Dialogs.Meleena
{
    public class YouNeedToUnencryptThisDataStick : Dialog
    {
        public YouNeedToUnencryptThisDataStick() : base(nameof(YouNeedToUnencryptThisDataStick)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(DataStick))
                   && GameState.Instance.IsThinking(nameof(HereIsTheSearchOrder));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
