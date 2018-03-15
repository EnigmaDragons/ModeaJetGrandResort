namespace SpaceResortMurder.Deductions
{
    public class ZaidShotRaymondsShip : Deduction
    {
        public ZaidShotRaymondsShip() : base(nameof(ZaidShotRaymondsShip)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
