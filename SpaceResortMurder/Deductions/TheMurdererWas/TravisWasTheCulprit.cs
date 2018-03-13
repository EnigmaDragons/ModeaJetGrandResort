namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class TravisWasTheCulprit : Deduction
    {
        public TravisWasTheCulprit() : base(nameof(TravisWasTheCulprit)) {}

        public override bool IsActive()
        {
            return false;
        }
    }
}
