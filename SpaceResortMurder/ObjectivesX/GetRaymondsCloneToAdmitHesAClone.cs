using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class GetRaymondsCloneToAdmitHesAClone : Objective
    {
        public GetRaymondsCloneToAdmitHesAClone() : base(nameof(GetRaymondsCloneToAdmitHesAClone)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(FoundYouRaymondsClone));
        }
    }
}
