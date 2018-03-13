using SpaceResortMurder.Dialogues.RaymondsClone;

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
            return GameState.Instance.IsThinking(nameof(GoToTheLobby))
                && GameState.Instance.IsThinking(nameof(YouBrokeIntoRaymondsShip));
        }
    }
}
