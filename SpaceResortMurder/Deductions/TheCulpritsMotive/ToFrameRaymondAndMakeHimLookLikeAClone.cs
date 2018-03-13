using SpaceResortMurder.Deductions.TheMurdererWas;
using SpaceResortMurder.Deductions.VictimsIdentity;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheCulpritsMotive
{
    public class ToFrameRaymondAndMakeHimLookLikeAClone : Deduction
    {
        public ToFrameRaymondAndMakeHimLookLikeAClone() : base(nameof(ToFrameRaymondAndMakeHimLookLikeAClone)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(TravisWasTheCulprit))
                   && CurrentGameState.Instance.IsThinking(nameof(TheVictimIsRaymondsClone));
        }
    }
}
