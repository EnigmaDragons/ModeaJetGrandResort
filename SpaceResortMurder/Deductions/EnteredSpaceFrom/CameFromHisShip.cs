namespace SpaceResortMurder.Deductions.EnteredSpaceFrom
{
    public class CameFromHisShip : Deduction
    {
        public CameFromHisShip() : base(nameof(CameFromHisShip)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
