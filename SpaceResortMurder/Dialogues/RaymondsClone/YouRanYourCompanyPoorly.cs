using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class YouRanYourCompanyPoorly : Dialogue
    {
        public YouRanYourCompanyPoorly() : base(nameof(YouRanYourCompanyPoorly))
        {
            IsExclusive = true;
        }

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YourBeingRidiculous));
        }
    }
}
