using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class YouNeedToUnencryptThisDataStick : Dialogue
    {
        public YouNeedToUnencryptThisDataStick() : base(nameof(YouNeedToUnencryptThisDataStick)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(DataStick))
                   && CurrentGameState.Instance.IsThinking(nameof(HereIsTheSearchOrder));
        }
    }
}
