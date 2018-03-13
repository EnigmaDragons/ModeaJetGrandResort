using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Deductions.VictimsIdentity;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class ToReplaceRaymondAsCEO : Deduction
    {
        public ToReplaceRaymondAsCEO() : base(nameof(ToReplaceRaymondAsCEO)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(RaymondsCloneWasTheCulprit))
                   && CurrentGameState.Instance.IsThinking(nameof(TheVictimIsRaymond));
        }
    }
}
