using Microsoft.Xna.Framework;
using SpaceResortMurder.Clues.PoliceSpaceCraft;
using SpaceResortMurder.Deductions.TimeFrameForMurder;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhatWasTheTimeFrameForTheMurder : Dilemma
    {
        public WhatWasTheTimeFrameForTheMurder() : base(new Vector2(575, 208), nameof(WhatWasTheTimeFrameForTheMurder), 
            new FromAnytimeUntilEightPM(),
            new SevenAMToEightPM(),
            new EightPMtoMidnight()) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(Clock));
        }
    }
}
