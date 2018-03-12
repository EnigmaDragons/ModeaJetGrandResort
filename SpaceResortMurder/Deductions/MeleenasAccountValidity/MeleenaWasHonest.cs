namespace SpaceResortMurder.Deductions.MeleenasAccountValidity
{
    public class MeleenaWasHonest : Deduction
    {
        public MeleenaWasHonest() : base(nameof(MeleenaWasHonest)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
