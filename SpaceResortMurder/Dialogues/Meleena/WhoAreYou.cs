namespace SpaceResortMurder.Dialogues.Meleena
{
    public class WhoAreYou : Dialogue
    {
        public WhoAreYou() : base(nameof(WhoAreYou)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
