using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.PoliceSpaceCraft;
using SpaceResortMurder.Deductions.TimeFrameForMurder;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhatWasTheTimeFrameForTheMurder : Dilemma
    {
        public WhatWasTheTimeFrameForTheMurder() : base(new Vector2(100, 150), nameof(WhatWasTheTimeFrameForTheMurder), 
            new FromAnytimeUntilEightPM(),
            new SevenAMToEightPM(),
            new EightPMtoMidnight()) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(Clock));
        }
    }
}
