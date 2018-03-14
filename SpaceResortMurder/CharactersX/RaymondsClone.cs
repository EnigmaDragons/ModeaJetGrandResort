using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.CharactersX
{
    public class RaymondsClone : Character
    {
        public RaymondsClone() : base("Raymond, CEO of Human Perfect", "characters/random_npc_01", new Size2(480, 1128), 
            new MeetingRaymondsClone(),
            new YourLookALikeIsDead(),
            new GoToTheLobby(),
            new DidYouChokeYourClone(),
            new MeleenaIdentifiedYourVoice()) {}

        public override string WhereAreYou()
        {
            return CurrentGameState.Instance.IsThinking(nameof(GoToTheLobby)) ? nameof(Lobby) : nameof(VacantRoom);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(1200, 258), new Size2(240, 564));
        }
    }
}
