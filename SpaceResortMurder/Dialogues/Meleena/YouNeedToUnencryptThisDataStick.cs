using SpaceResortMurder.Clues.MeleenasSpaceCraft;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class YouNeedToUnencryptThisDataStick : Dialogue
    {
        public YouNeedToUnencryptThisDataStick() : base(nameof(YouNeedToUnencryptThisDataStick)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(DataStick))
                   && GameState.Instance.IsThinking(nameof(HereIsTheSearchOrder));
        }
    }
}
