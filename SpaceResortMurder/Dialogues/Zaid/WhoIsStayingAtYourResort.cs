using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class WhoIsStayingAtYourResort : Dialogue
    {
        public WhoIsStayingAtYourResort() : base(nameof(WhoIsStayingAtYourResort)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhoAreYouZaid));
        }
    }
}
