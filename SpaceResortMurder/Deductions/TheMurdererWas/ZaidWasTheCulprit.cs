using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class ZaidWasTheCulprit : Deduction
    {
        public ZaidWasTheCulprit() : base(nameof(ZaidWasTheCulprit)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(YouWereNotAcceptedForBetaTesting));
        }
    }
}
