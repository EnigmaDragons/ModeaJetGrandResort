using SpaceResortMurder.Clues;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Scenes
{
    public class BlackRoomScene : LocationScene
    {
        public BlackRoomScene() : base(nameof(BlackRoom)) {}

        public override void Init()
        {
            InitBase();
            AddClue(new Necronomicon());
        }
    }
}
