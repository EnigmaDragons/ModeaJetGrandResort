using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions
{
    public class ZaidShotRaymondsShip : Deduction
    {
        public ZaidShotRaymondsShip() : base(nameof(ZaidShotRaymondsShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ResortManagerZaid)) || CurrentGameState.IsThinking(nameof(WhoAreYouZaid));
        }
    }
}
