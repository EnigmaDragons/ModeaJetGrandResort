namespace SpaceResortMurder.Dialogues.Meleena
{
    public class MeleenaHeardRaymondsVoice : Dialogue
    {
        public MeleenaHeardRaymondsVoice() : base(nameof(MeleenaHeardRaymondsVoice))
        {
            AutoPlay = true;
        }

        public override bool IsActive()
        {
            return false;
        }
    }
}
