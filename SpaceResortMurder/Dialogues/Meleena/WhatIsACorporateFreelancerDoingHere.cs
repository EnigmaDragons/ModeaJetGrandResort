using SpaceResortMurder.Dialogues.Warren;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class WhatIsACorporateFreelancerDoingHere : Dialogue
    {
        public WhatIsACorporateFreelancerDoingHere() : base(nameof(WhatIsACorporateFreelancerDoingHere)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
