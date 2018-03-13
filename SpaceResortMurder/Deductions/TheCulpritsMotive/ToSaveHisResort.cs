using SpaceResortMurder.Deductions.TheMurdererWas;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class ToSaveHisResort : Deduction
    {
        public ToSaveHisResort() : base(nameof(ToSaveHisResort)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(ZaidWasTheCulprit));
        }
    }
}
