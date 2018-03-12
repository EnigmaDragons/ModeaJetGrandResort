namespace SpaceResortMurder.Deductions.CauseOfDeath
{
    public class ChokedBySomeone : Deduction
    {
        public ChokedBySomeone() : base(nameof(ChokedBySomeone)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
