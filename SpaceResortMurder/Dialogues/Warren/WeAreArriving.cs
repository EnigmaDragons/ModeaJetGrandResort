namespace SpaceResortMurder.Dialogues.Warren
{
    public class WeAreArriving : Dialogue
    {
        public WeAreArriving() : base(nameof(WeAreArriving)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
