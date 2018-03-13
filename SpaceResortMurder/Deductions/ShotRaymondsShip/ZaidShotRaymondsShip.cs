using SpaceResortMurder.Dialogues.Warren;

namespace SpaceResortMurder.Deductions
{
    public class ZaidShotRaymondsShip : Deduction
    {
        public ZaidShotRaymondsShip() : base(nameof(ZaidShotRaymondsShip)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
