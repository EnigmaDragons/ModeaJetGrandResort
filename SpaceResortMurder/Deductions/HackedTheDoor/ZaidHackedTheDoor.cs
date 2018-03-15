namespace SpaceResortMurder.Deductions
{
    public class ZaidHackedTheDoor : Deduction
    {
        public ZaidHackedTheDoor() : base(nameof(ZaidHackedTheDoor)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
