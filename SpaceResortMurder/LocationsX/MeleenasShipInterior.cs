using Microsoft.Xna.Framework;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.LocationsX
{
    public class MeleenasShipInterior : Location
    {
        public MeleenasShipInterior() : base(nameof(MeleenasShipInterior), "Meleena's Space Craft", new Vector2(800, 400)) {}

        public override bool IsAvailable()
        {
            return CurrentGameState.Instance.IsThinking(nameof(HereIsTheSearchOrder))
                   || CurrentGameState.Instance.IsThinking(nameof(ImOnlyInvestigatingTheMurder));
        }
    }
}
