using Microsoft.Xna.Framework;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.State;

namespace SpaceResortMurder.LocationsX
{
    public class VacantRoom : Location
    {
        public VacantRoom() : base(nameof(VacantRoom), "Vacant Resort Room", new Vector2(500, 700)) {}

        public override bool IsAvailable()
        {
            return CurrentGameState.Instance.IsThinking(nameof(WhyIsTravisAtTheResort));
        }
    }
}
