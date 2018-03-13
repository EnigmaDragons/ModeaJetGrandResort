namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class MeetingRaymondsClone : Dialogue
    {
        public MeetingRaymondsClone() : base(nameof(MeetingRaymondsClone))
        {
            AutoPlay = true;
        }

        public override bool IsActive()
        {
            return true;
        }
    }
}
