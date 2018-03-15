namespace SpaceResortMurder.Deductions.LaunchedTheShip
{
    public class MeleenaLaunchedTheShip : Deduction
    {
        public MeleenaLaunchedTheShip() : base(nameof(MeleenaLaunchedTheShip)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
