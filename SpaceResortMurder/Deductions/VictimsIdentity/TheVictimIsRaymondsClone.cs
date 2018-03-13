namespace SpaceResortMurder.Deductions.VictimsIdentity
{
    public class TheVictimIsRaymondsClone : Deduction
    {
        public TheVictimIsRaymondsClone() : base(nameof(TheVictimIsRaymondsClone)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
