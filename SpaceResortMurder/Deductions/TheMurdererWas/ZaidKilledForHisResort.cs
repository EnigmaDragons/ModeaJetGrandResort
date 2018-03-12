using System;
using SpaceResortMurder.Dialogs.Zaid;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class ZaidKilledForHisResort : Deduction
    {
        public ZaidKilledForHisResort() : base(nameof(ZaidKilledForHisResort)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(YouWereNotAcceptedForBetaTesting));
        }
    }
}
