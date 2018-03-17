using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class YouCanKeepYourLife : Dialogue
    {
        public YouCanKeepYourLife() : base(nameof(YouCanKeepYourLife))
        {
            IsExclusive = true;
        }

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YourBeingRidiculous))
                && !CurrentGameState.IsThinking(nameof(YouRanYourCompanyPoorly));
        }
    }
}
