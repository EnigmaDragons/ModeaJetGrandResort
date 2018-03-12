﻿namespace SpaceResortMurder.Dialogs.Zaid
{
    public class DidRaymondApproveYourResort : Dialog
    {
        public DidRaymondApproveYourResort() : base(nameof(DidRaymondApproveYourResort)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(WhyWasRaymondHere));
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
