namespace SpaceResortMurder.Deductions.ClonesDesign
{
    public class DesignedToKill : Deduction
    {
        public DesignedToKill() : base(nameof(DesignedToKill)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
