using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions
{
    public class ZaidHackedTheDoor : Deduction
    {
        public ZaidHackedTheDoor() : base(nameof(ZaidHackedTheDoor)) {}

        public override bool IsActive()
        {
            return (CurrentGameState.IsThinking(nameof(ResortManagerZaid)) || CurrentGameState.IsThinking(nameof(WhoAreYouZaid)));
        }
    }
}
