using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class WhyKeepCloneSecret : Dialogue
    {
        public WhyKeepCloneSecret() : base(nameof(WhyKeepCloneSecret)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(FoundYouRaymondsClone));
        }
    }
}
