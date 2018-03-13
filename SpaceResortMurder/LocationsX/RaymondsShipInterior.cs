using Microsoft.Xna.Framework;
using SpaceResortMurder.Dialogues.Warren;

namespace SpaceResortMurder.LocationsX
{
    public class RaymondsShipInterior : Location
    {
        public RaymondsShipInterior() : base(nameof(RaymondsShipInterior), "Raymond's Space Craft", new Vector2(800, 150)) {}

        public override bool IsAvailable()
        {
            return GameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
