namespace SpaceResortMurder.Deductions.CauseOfDeath
{
    public class LackOfOxygenInSpace : Deduction
    {
        public LackOfOxygenInSpace() : base(nameof(LackOfOxygenInSpace)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
