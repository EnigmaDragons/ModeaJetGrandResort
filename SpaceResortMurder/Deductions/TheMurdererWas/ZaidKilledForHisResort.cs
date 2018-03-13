using System;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class ZaidKilledForHisResort : Deduction
    {
        public ZaidKilledForHisResort() : base(nameof(ZaidKilledForHisResort)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(YouWereNotAcceptedForBetaTesting));
        }
    }
}
