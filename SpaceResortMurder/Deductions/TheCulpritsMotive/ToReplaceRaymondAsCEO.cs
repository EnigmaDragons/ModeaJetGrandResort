using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class ToReplaceRaymondAsCEO : Deduction
    {
        public ToReplaceRaymondAsCEO() : base(nameof(ToReplaceRaymondAsCEO)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsCloneWasTheCulprit));
        }
    }
}
