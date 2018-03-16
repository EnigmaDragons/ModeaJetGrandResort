using SpaceResortMurder.CharactersX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class ElectricDischarge : Dialogue
    {
        public ElectricDischarge() : base(nameof(ElectricDischarge)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(CEORaymondsClone)) 
                && CurrentGameState.IsThinking(nameof(FoundYouRaymondsClone));
        }
    }
}
