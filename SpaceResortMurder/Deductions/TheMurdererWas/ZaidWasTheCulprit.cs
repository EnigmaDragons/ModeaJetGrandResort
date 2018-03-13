using SpaceResortMurder.Dialogues.Zaid;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class ZaidWasTheCulprit : Deduction
    {
        public ZaidWasTheCulprit() : base(nameof(ZaidWasTheCulprit)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(YouWereNotAcceptedForBetaTesting));
        }
    }
}
