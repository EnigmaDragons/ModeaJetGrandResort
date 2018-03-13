namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class GoToTheLobby : Dialogue
    {
        public GoToTheLobby() : base(nameof(GoToTheLobby)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
