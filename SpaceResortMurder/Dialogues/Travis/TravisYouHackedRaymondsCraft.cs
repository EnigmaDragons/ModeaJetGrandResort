using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class TravisYouHackedRaymondsCraft : Dialogue
    {
        public TravisYouHackedRaymondsCraft() : base(nameof(TravisYouHackedRaymondsCraft)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(TravisHackedTheDoor));
        }
    }
}
