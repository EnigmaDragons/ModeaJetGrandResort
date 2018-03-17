using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Clues.RaymondsSpaceCraft;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.CharactersX
{
    public class HackerMeleena : Character
    {
        public HackerMeleena() : base(nameof(HackerMeleena), new Size2(480, 1128),
            new WhoAreYou(),
            new MeleenasAccount(),
            new CorporateFreelancersCantNormallyAffordPersonalSpaceCrafts(),
            new SearchYourCraftForEvidence(),
            new YouHaveARatherCleanRecord(),
            new YouAreAHacker(),
            new HereIsTheSearchOrder(),
            new IWontReportDataRaven(),
            new DeckersMakeTheWorldWorse(),
            new ProveIt(),
            new YouBrokeIntoRaymondsShip(),
            new MeleenaYouShotTheShip(),
            new YouDidntHearAVoiceYouLaunchedTheShip()) {}

        public override string WhereAreYou()
        {
            return CurrentGameState.IsThinking(nameof(RaymondsCorpse))
                ? nameof(DockingBay)
                : nameof(MeleenasShipInterior);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(1560, 258), new Size2(240, 564));
        }
    }
}
