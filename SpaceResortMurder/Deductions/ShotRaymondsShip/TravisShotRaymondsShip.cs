namespace SpaceResortMurder.Deductions
{
    public class TravisShotRaymondsShip : Deduction
    {
        public TravisShotRaymondsShip() : base(nameof(TravisShotRaymondsShip)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
