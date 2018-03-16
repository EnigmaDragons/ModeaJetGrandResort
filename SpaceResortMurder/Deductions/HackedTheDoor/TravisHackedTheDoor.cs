using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions
{
    public class TravisHackedTheDoor : Deduction
    {
        public TravisHackedTheDoor() : base(nameof(TravisHackedTheDoor)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(WhoIsStayingAtYourResort))
                && !CurrentGameState.IsThinking(nameof(YouBrokeIntoRaymondsShip));
        }
    }
}
