
using MonoDragons.Core.AudioSystem;

namespace SpaceResortMurder.LocationsX
{
    public class PoliceCruiserInteriorScene : LocationScene
    {
        public PoliceCruiserInteriorScene() : base(GameObjects.Locations[nameof(PoliceCruiserInterior)], "Locations/PoliceCruiserPainted") {}

        protected override void OnInit()
        {
            Audio.PlayMusic("PoliceCruiser", 0.4f);
        }
    }
}
