namespace SpaceResortMurder.Deductions.TimeFrameForMurder
{
    public class SevenAMToEightPM : Deduction
    {
        public SevenAMToEightPM() : base(nameof(SevenAMToEightPM)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
