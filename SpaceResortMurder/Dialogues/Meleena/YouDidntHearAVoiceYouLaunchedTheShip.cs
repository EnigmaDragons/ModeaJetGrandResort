using SpaceResortMurder.Deductions.LaunchedTheShip;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class YouDidntHearAVoiceYouLaunchedTheShip : Dialogue
    {
        public YouDidntHearAVoiceYouLaunchedTheShip() : base(nameof(YouDidntHearAVoiceYouLaunchedTheShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YouBrokeIntoRaymondsShip)) 
                && CurrentGameState.IsThinking(nameof(MeleenaLaunchedTheShip));
        }
    }
}
