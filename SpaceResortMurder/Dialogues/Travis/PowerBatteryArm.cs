using SpaceResortMurder.CharactersX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Travis
{
    public class PowerBatteryArm : Dialogue
    {
        public PowerBatteryArm() : base(nameof(PowerBatteryArm)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ResearcherTravis));
        }
    }
}
