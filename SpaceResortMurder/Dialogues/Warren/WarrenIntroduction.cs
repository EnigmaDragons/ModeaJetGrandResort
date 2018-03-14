namespace SpaceResortMurder.Dialogues.Warren
{
    public class WarrenIntroduction : Dialogue
    {
        public WarrenIntroduction() : base(nameof(WarrenIntroduction)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
