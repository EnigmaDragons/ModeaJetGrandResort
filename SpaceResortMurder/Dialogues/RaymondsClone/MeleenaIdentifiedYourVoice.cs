using SpaceResortMurder.Deductions.LaunchedTheShip;
using SpaceResortMurder.Deductions.MeleenasAccountValidity;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class MeleenaIdentifiedYourVoice : Dialogue
    {
        public MeleenaIdentifiedYourVoice() : base(nameof(MeleenaIdentifiedYourVoice)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(MeleenaWasHonest))
                   && CurrentGameState.Instance.IsThinking(nameof(MeleenaHeardRaymondsVoice))
                   && CurrentGameState.Instance.IsThinking(nameof(RaymondsCloneLaunchedTheShip));
        }
    }
}
