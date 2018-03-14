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
            return CurrentGameState.IsThinking(nameof(MeleenaWasHonest))
                   && CurrentGameState.IsThinking(nameof(MeleenaHeardRaymondsVoice))
                   && CurrentGameState.IsThinking(nameof(RaymondsCloneLaunchedTheShip));
        }
    }
}
