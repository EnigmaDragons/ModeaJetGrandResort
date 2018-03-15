namespace SpaceResortMurder.Deductions.LaunchedTheShip
{
    public class ZaidLaunchedTheShip : Deduction
    {
        public ZaidLaunchedTheShip() : base(nameof(ZaidLaunchedTheShip)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
