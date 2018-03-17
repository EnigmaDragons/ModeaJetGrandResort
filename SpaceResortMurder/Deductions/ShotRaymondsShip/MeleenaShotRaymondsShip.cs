using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions
{
    public class MeleenaShotRaymondsShip : Deduction
    {
        public MeleenaShotRaymondsShip() : base(nameof(MeleenaShotRaymondsShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(HackerMeleena)) && CurrentGameState.IsThinking(nameof(WhoAreYou));
        }
    }
}
