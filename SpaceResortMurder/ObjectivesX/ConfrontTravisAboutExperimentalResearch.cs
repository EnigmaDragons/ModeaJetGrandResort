using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class ConfrontTravisAboutExperimentalResearch : Objective
    {
        public ConfrontTravisAboutExperimentalResearch() : base(nameof(ConfrontTravisAboutExperimentalResearch)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(UnencryptedDataDrive));
        }
    }
}
