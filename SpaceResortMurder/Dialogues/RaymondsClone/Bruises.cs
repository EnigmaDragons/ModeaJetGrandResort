using SpaceResortMurder.CharactersX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class Bruises : Dialogue
    {
        public Bruises() : base(nameof(Bruises)) { }

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(CEORaymondsClone)) 
                && CurrentGameState.IsThinking(nameof(FoundYouRaymondsClone));
        }
    }
}
