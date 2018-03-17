using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.ClonesDesign;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WasTheCloneDesignedToKill : Dilemma
    {
        public WasTheCloneDesignedToKill() : base(new Vector2(1490, 593), nameof(WasTheCloneDesignedToKill), 
            new DesignedToKill(),
            new PerfectedDesign()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(ViolentExperimentalResearch));
        }
    }
}
