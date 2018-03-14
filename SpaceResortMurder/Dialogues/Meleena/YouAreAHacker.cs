using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class YouAreAHacker : Dialogue
    {
        public YouAreAHacker() : base(nameof(YouAreAHacker)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(HackingRig));
        }
    }
}
