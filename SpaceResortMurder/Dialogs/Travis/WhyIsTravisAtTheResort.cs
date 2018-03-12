using System;

namespace SpaceResortMurder.Dialogs.Travis
{
    public class WhyIsTravisAtTheResort : Dialog
    {
        public WhyIsTravisAtTheResort() : base(nameof(WhyIsTravisAtTheResort)) {}

        public override bool IsActive()
        {
            throw new NotImplementedException();
        }

        public override bool IsImmediatelyStarted()
        {
            return false;
        }
    }
}
