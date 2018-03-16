using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class ZaidYouHackedRaymondsDoor : Dialogue
    {
        public ZaidYouHackedRaymondsDoor() : base(nameof(ZaidYouHackedRaymondsDoor)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ZaidHackedTheDoor));
        }
    }
}
