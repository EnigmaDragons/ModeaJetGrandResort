namespace SpaceResortMurder.Deductions.VictimsIdentity
{
    public class TheVictimIsRaymond : Deduction
    {
        public TheVictimIsRaymond() : base(nameof(TheVictimIsRaymond)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
