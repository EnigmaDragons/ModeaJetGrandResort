using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class DoYouHaveAnyCamerasAtYourResort : Dialogue
    {
        public DoYouHaveAnyCamerasAtYourResort() : base(nameof(DoYouHaveAnyCamerasAtYourResort)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhoAreYouZaid));
        }
    }
}
