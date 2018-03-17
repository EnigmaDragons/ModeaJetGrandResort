using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Zaid
{
    public class WhyWasRaymondHere : Dialogue
    {
        public WhyWasRaymondHere() : base(nameof(WhyWasRaymondHere)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhoIsStayingAtYourResort)) 
                && CurrentGameState.IsThinking(nameof(WhySoFewPeopleAtTheResort)) 
                && CurrentGameState.IsThinking(nameof(DoYouHaveAnyCamerasAtYourResort));
        }
    }
}
