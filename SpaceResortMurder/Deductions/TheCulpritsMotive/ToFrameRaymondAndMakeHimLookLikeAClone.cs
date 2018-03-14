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
            return CurrentGameState.IsThinking(nameof(TravisWasTheCulprit))
                   && CurrentGameState.IsThinking(nameof(TheVictimIsRaymondsClone));
        }
    }
}
