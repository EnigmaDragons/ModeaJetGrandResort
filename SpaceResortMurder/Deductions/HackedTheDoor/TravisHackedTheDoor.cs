namespace SpaceResortMurder.Deductions
{
    public class TravisHackedTheDoor : Deduction
    {
        public TravisHackedTheDoor() : base(nameof(TravisHackedTheDoor)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
