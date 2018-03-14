namespace SpaceResortMurder.Deductions.TimeFrameForMurder
{
    public class EightPMtoMidnight : Deduction
    {
        public EightPMtoMidnight() : base(nameof(EightPMtoMidnight)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
