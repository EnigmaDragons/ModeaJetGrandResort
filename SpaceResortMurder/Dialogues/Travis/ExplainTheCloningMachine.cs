using SpaceResortMurder.Clues.CloningRoom;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class ExplainTheCloningMachine : Dialogue
    {
        public ExplainTheCloningMachine() : base(nameof(ExplainTheCloningMachine)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(CloningChamber)) && CurrentGameState.IsThinking(nameof(DidYouWorkWithRaymond));
        }
    }
}
