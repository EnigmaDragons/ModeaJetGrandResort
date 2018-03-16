using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.ZaidsResortForBetaTesting
{
    public class ZaidsResortAccepted : Deduction
    {
        public ZaidsResortAccepted() : base(nameof(ZaidsResortAccepted)) {}

        public override bool IsActive()
        {
            return !CurrentGameState.IsThinking(nameof(YouWereNotAcceptedForBetaTesting));
        }
    }
}
