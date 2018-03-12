namespace SpaceResortMurder.Deductions.MeleenasAccountValidity
{
    public class MeleenaIsLying : Deduction
    {
        public MeleenaIsLying() : base(nameof(MeleenaIsLying)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
