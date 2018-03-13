using Microsoft.Xna.Framework;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.State;

namespace SpaceResortMurder.LocationsX
{
    public class RaymondsShipInterior : Location
    {
        public RaymondsShipInterior() : base(nameof(RaymondsShipInterior), "Raymond's Space Craft", new Vector2(800, 150)) {}

        public override bool IsAvailable()
        {
            return CurrentGameState.Instance.IsThinking(nameof(MeetingWarren));
        }
    }
}
