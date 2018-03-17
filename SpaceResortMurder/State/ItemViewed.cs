namespace SpaceResortMurder.State
{
    public class ItemViewed
    {
        public string Item { get; }

        public ItemViewed(string item)
        {
            Item = item;
        }

        public override string ToString() => $"ItemViewed: {Item}";
    }
}