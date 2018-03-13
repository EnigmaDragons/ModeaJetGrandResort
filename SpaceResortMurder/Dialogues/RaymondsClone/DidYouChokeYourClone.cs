using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class DidYouChokeYourClone : Dialogue
    {
        public DidYouChokeYourClone() : base(nameof(DidYouChokeYourClone)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(RaymondsCorpse));
        }
    }
}
