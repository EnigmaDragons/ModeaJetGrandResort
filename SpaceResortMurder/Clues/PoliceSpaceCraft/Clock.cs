using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Clues.PoliceSpaceCraft
{
    public class Clock : Clue
    {
        public Clock(Transform2 sceneTransform) : base(
            "Clues/Clock-Alt",
            sceneTransform,
            new Size2(550, 550),
            nameof(Clock))
        {
            IsActive = () => CurrentGameState.IsThinking(nameof(PettyTheftAt12));
        }
    }
}
