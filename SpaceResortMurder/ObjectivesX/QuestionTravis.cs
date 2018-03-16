using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class QuestionTravis : Objective
    {
        public QuestionTravis() : base(nameof(QuestionTravis)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhoIsStayingAtYourResort))
                && !CurrentGameState.IsThinking(nameof(DidYouWorkWithRaymond));
        }
    }
}
