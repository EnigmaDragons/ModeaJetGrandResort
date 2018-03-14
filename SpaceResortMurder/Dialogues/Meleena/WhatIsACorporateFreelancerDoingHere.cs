using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class WhatIsACorporateFreelancerDoingHere : Dialogue
    {
        public WhatIsACorporateFreelancerDoingHere() : base(nameof(WhatIsACorporateFreelancerDoingHere)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(MeetingWarren));
        }
    }
}
