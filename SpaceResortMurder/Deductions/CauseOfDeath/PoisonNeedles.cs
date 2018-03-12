namespace SpaceResortMurder.Deductions.CauseOfDeath
{
    public class PoisonNeedles : Deduction
    {
        public PoisonNeedles() : base(nameof(PoisonNeedles)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
