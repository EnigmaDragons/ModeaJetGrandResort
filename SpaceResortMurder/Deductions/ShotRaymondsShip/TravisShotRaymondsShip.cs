using SpaceResortMurder.Dialogs.Warren;

namespace SpaceResortMurder.Deductions
{
    public class TravisShotRaymondsShip : Deduction
    {
        public TravisShotRaymondsShip() : base(nameof(TravisShotRaymondsShip)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
