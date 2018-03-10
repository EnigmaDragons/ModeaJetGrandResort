namespace SpaceResortMurder.Dialogs
{
    public class WhoWasMurdered : Dialog
    {
        public WhoWasMurdered() : base("Who was murdered?", nameof(WhoWasMurdered), 1600, "Raymond was murdered", "Sucks for him!") {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
