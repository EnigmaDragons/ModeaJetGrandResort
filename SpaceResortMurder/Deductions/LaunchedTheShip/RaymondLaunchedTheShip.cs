namespace SpaceResortMurder.Deductions.LaunchedTheShip
{
    public class RaymondLaunchedTheShip : Deduction
    {
        public RaymondLaunchedTheShip() : base(nameof(RaymondLaunchedTheShip)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
