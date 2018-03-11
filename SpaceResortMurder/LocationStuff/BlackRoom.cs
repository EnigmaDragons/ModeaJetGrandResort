using Microsoft.Xna.Framework;

namespace SpaceResortMurder.LocationStuff
{
    public class BlackRoom : Location
    {
        public BlackRoom() : base(nameof(BlackRoom), "Black Room", new Vector2(800, 450)) {}

        public override bool IsAvailable()
        {
            return true;
        }
    }
}
