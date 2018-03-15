namespace SpaceResortMurder.Deductions
{
    public class MeleenaShotRaymondsShip : Deduction
    {
        public MeleenaShotRaymondsShip() : base(nameof(MeleenaShotRaymondsShip)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
