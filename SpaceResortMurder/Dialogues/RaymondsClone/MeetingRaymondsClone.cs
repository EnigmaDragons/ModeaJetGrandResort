namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class MeetingRaymondsClone : Dialogue
    {
        public MeetingRaymondsClone() : base(nameof(MeetingRaymondsClone))
        {
            AutoPlay = false;
        }

        public override bool IsActive()
        {
            return false;
        }
    }
}
