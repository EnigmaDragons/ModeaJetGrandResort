using SpaceResortMurder.Clues.PoliceSpaceCraft;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class LookAroundForClues : Objective
    {
        public LookAroundForClues() : base(nameof(LookAroundForClues)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(PettyTheftAt12))
                && !CurrentGameState.IsThinking(nameof(Clock));
        }
    }
}
