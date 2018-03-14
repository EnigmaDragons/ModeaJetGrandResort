namespace SpaceResortMurder.Dialogues.Warren
{
    public class MeetingWarren : Dialogue
    {
        public MeetingWarren() : base(nameof(MeetingWarren))
        {
            AutoPlay = false;
        }

        public override bool IsActive()
        {
            return false;
        }
    }
}
