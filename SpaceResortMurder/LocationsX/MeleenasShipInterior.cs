using Microsoft.Xna.Framework;
using SpaceResortMurder.Dialogues.Meleena;

namespace SpaceResortMurder.LocationsX
{
    public class MeleenasShipInterior : Location
    {
        public MeleenasShipInterior() : base(nameof(MeleenasShipInterior), "Meleena's Space Craft", new Vector2(800, 400)) {}

        public override bool IsAvailable()
        {
            return GameState.Instance.IsThinking(nameof(HereIsTheSearchOrder))
                   || GameState.Instance.IsThinking(nameof(ImOnlyInvestigatingTheMurder));
        }
    }
}
