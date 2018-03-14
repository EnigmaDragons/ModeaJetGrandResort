using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class ToSaveHisResort : Deduction
    {
        public ToSaveHisResort() : base(nameof(ToSaveHisResort)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ZaidWasTheCulprit));
        }
    }
}
