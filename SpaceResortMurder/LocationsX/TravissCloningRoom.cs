using Microsoft.Xna.Framework;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.State;

namespace SpaceResortMurder.LocationsX
{
    public class TravissCloningRoom : Location
    {
        public TravissCloningRoom() : base(nameof(TravissCloningRoom), "Travis's Cloning Room", new Vector2(1300, 400)) {}

        public override bool IsAvailable()
        {
            return CurrentGameState.Instance.IsThinking(nameof(InvestigateYourCloningMachine));
        }
    }
}
