namespace SpaceResortMurder.Dialogues.Warren
{
    public class WarrenIntroduction : Dialogue
    {
        public WarrenIntroduction() : base(nameof(WarrenIntroduction)) { IsExclusive = true; }

        public override bool IsActive()
        {
            return true;
        }
    }
}
