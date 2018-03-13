namespace SpaceResortMurder.Deductions.CauseOfDeath
{
    public class PushedOutOfHisShip : Deduction
    {
        public PushedOutOfHisShip() : base(nameof(PushedOutOfHisShip)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
