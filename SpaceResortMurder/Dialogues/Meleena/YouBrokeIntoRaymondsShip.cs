using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class YouBrokeIntoRaymondsShip : Dialogue
    {
        public YouBrokeIntoRaymondsShip() : base(nameof(YouBrokeIntoRaymondsShip)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeleenaHackedTheDoor)) 
                && CurrentGameState.IsThinking(nameof(SkeletonKey)) 
                && (CurrentGameState.IsThinking(nameof(IWontReportDataRaven))
                    || CurrentGameState.IsThinking(nameof(DeckersMakeTheWorldWorse)));
        }
    }
}
