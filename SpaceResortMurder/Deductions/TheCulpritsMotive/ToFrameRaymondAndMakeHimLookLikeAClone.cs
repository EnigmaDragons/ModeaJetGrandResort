using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Deductions.VictimsIdentity;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class ToFrameRaymondAndMakeHimLookLikeAClone : Deduction
    {
        public ToFrameRaymondAndMakeHimLookLikeAClone() : base(nameof(ToFrameRaymondAndMakeHimLookLikeAClone)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(TravisWasTheCulprit))
                   && GameState.Instance.IsThinking(nameof(TheVictimIsRaymondsClone));
        }
    }
}
