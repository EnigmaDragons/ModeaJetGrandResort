using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class YourCloneShotYourShip : Dialogue
    {
        public YourCloneShotYourShip() : base(nameof(YourCloneShotYourShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondShotHisOwnShip)) && CurrentGameState.IsThinking(nameof(T71EnergyBlaster));
        }
    }
}
