namespace SpaceResortMurder.Deductions.ClonesDesign
{
    public class PerfectedDesign : Deduction
    {
        public PerfectedDesign() : base(nameof(PerfectedDesign)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
