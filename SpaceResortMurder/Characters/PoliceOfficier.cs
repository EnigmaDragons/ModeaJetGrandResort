using SpaceResortMurder.Dialogs;

namespace SpaceResortMurder.Characters
{
    public class PoliceOfficier : Person
    {
        public PoliceOfficier() : base(new WhoWasMurdered(), new WhyWouldAnyoneHireYouPolice()) {}
    }
}
