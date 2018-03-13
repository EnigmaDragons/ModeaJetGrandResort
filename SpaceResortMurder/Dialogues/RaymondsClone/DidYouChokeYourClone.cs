using SpaceResortMurder.Clues.RaymondsSpaceCraft;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class DidYouChokeYourClone : Dialogue
    {
        public DidYouChokeYourClone() : base(nameof(DidYouChokeYourClone)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(RaymondsCorpse));
        }
    }
}
