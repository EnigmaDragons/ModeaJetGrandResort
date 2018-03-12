namespace SpaceResortMurder.Deductions
{
    public class RaymondShotHisOwnShip : Deduction
    {
        public RaymondShotHisOwnShip() : base(nameof(RaymondShotHisOwnShip)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
