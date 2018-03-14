namespace SpaceResortMurder.Deductions.TimeFrameForMurder
{
    public class FromAnytimeUntilEightPM : Deduction
    {
        public FromAnytimeUntilEightPM() : base(nameof(FromAnytimeUntilEightPM)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
