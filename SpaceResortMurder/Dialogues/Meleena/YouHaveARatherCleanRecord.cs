using SpaceResortMurder.CharactersX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class YouHaveARatherCleanRecord : Dialogue
    {
        public YouHaveARatherCleanRecord() : base(nameof(YouHaveARatherCleanRecord)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(HackerMeleena));
        }
    }
}
