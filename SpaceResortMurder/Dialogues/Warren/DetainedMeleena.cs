using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Warren
{
    public class DetainedMeleena : Dialogue
    {
        public DetainedMeleena() : base(nameof(DetainedMeleena)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsCorpse));
        }
    }
}
