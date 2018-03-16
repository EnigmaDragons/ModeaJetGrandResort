using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class IWontReportDataRaven : Dialogue
    {
        public IWontReportDataRaven() : base(nameof(IWontReportDataRaven)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YouAreAHacker));
        }
    }
}
