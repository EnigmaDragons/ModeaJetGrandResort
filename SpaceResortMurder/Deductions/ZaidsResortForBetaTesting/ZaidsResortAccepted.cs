namespace SpaceResortMurder.Deductions.ZaidsResortForBetaTesting
{
    public class ZaidsResortAccepted : Deduction
    {
        public ZaidsResortAccepted() : base(nameof(ZaidsResortAccepted)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
