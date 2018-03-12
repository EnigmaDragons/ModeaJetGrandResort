namespace SpaceResortMurder.Deductions.ZaidsResortForBetaTesting
{
    public class ZaidsResortDeclined : Deduction
    {
        public ZaidsResortDeclined() : base(nameof(ZaidsResortDeclined)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
