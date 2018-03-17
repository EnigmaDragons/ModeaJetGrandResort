namespace SpaceResortMurder.Deductions.ElectricalBurnsComeFrom
{
    public class SomethingElse : Deduction
    {
        public SomethingElse() : base(nameof(SomethingElse)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
