using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.CharactersX
{
    public class OfficerWarren : Character
    {
        public OfficerWarren() : base(nameof(OfficerWarren), new Size2(480, 1128), 
            new WarrenIntroduction(),
            new PettyTheftAt12(),
            new AnytimeUpTilNow(),
            new BetweenSevenAMToEightPM(),
            new WeHaveUntilMidnight(),
            new DetainedMeleena(),
            new NeedASearchOrder(),
            new IsTheSearchOrderReady()) {}

        public override string WhereAreYou()
        {
            return CurrentGameState.IsThinking(nameof(BetweenSevenAMToEightPM)) 
                ? nameof(DockingBay) 
                : nameof(PoliceCruiserInterior);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(215, 450), Rotation2.Default, new Size2(360, 846), 0.8f);
        }
    }
}
