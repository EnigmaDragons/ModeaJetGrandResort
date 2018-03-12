namespace SpaceResortMurder.ResolutionsX
{
    public class IAmLeaving : Resolution
    {
        public IAmLeaving() : base(nameof(IAmLeaving)) { }

        public override bool IsActive()
        {
            return true;
        }
    }
}
