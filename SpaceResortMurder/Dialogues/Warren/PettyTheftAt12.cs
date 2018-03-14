using SpaceResortMurder.CharactersX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Warren
{
    public class PettyTheftAt12 : Dialogue
    {
        public PettyTheftAt12() : base(nameof(PettyTheftAt12)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(OfficerWarren));
        }
    }
}
