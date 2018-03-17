namespace SpaceResortMurder.Deductions.ElectricalBurnsComeFrom
{
    public class AStunGun : Deduction
    {
        public AStunGun() : base(nameof(AStunGun)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
