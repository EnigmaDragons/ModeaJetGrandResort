using SpaceResortMurder.Dialogs.Warren;

namespace SpaceResortMurder.Dialogs.Meleena
{
    public class WhatIsACorporateFreelancerDoingHere : Dialog
    {
        public WhatIsACorporateFreelancerDoingHere() : base(nameof(WhatIsACorporateFreelancerDoingHere)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
