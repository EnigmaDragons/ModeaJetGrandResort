using SpaceResortMurder.DilemmasX;

namespace SpaceResortMurder.Dialogs
{
    public class DidYouKillHimZaid : Dialog
    {
        public DidYouKillHimZaid() : base("Did you kill him?", nameof(DidYouKillHimZaid), 1600, "No I did not!", "You seem suspicious") {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(WhoKilledRaymond));
        }
    }
}
