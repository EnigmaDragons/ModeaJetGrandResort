namespace SpaceResortMurder.Deductions.CauseOfDeath
{
    public class KilledInSpace : Deduction
    {
        public KilledInSpace() : base(nameof(KilledInSpace)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
