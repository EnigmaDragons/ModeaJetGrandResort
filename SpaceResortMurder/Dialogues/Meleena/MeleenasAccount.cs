using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class MeleenasAccount : Dialogue
    {
        public MeleenasAccount() : base(nameof(MeleenasAccount)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhoAreYou));
        }
    }
}
