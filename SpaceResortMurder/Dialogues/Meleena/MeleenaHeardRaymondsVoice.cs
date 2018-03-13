using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class MeleenaHeardRaymondsVoice : Dialogue
    {
        public MeleenaHeardRaymondsVoice() : base(nameof(MeleenaHeardRaymondsVoice))
        {
            AutoPlay = true;
        }

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(GoToTheLobby))
                && CurrentGameState.Instance.IsThinking(nameof(YouBrokeIntoRaymondsShip));
        }
    }
}
