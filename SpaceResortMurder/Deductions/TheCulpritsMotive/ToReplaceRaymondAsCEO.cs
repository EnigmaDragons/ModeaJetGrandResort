using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Deductions.VictimsIdentity;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class ToReplaceRaymondAsCEO : Deduction
    {
        public ToReplaceRaymondAsCEO() : base(nameof(ToReplaceRaymondAsCEO)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(RaymondsCloneWasTheCulprit))
                   && GameState.Instance.IsThinking(nameof(TheVictimIsRaymond));
        }
    }
}
