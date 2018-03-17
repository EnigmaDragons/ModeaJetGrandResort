using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class IWontReportDataRaven : Dialogue
    {
        public IWontReportDataRaven() : base(nameof(IWontReportDataRaven))
        {
            IsExclusive = true;
        }

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YouAreAHacker))
                && !CurrentGameState.IsThinking(nameof(DeckersMakeTheWorldWorse));
        }
    }
}
