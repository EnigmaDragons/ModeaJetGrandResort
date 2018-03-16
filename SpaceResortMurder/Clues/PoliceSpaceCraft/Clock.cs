using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Clues.PoliceSpaceCraft
{
    public class Clock : Clue
    {
        public Clock(Transform2 sceneTransform) : base(
            "Clues/Clock",
            sceneTransform,
            new Size2(330, 330),
            nameof(Clock),
            "Clock")
        {
            IsActive = () => CurrentGameState.IsThinking(nameof(PettyTheftAt12));
        }
    }
}
