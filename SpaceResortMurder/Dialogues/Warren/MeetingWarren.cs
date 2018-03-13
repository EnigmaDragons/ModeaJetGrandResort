namespace SpaceResortMurder.Dialogues.Warren
{
    public class MeetingWarren : Dialogue
    {
        public MeetingWarren() : base(nameof(MeetingWarren))
        {
            AutoPlay = true;
        }

        public override bool IsActive()
        {
            return true;
        }
    }
}
