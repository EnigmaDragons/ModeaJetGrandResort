namespace SpaceResortMurder.Dialogs
{
    public class DidYouKillHimZaid : Dialog
    {
        public DidYouKillHimZaid() : base("Did you kill him?", nameof(DidYouKillHimZaid), 1600) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(WhoWasMurdered));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
