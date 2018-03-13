using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.MeleenasAccountValidity;
using SpaceResortMurder.Dialogues.Meleena;

namespace SpaceResortMurder.DilemmasX
{
    public class WasMeleenaTellingTheTruthAboutWhatHappenedOnRaymondsShip : Dilemma
    {
        public WasMeleenaTellingTheTruthAboutWhatHappenedOnRaymondsShip() : base(new Vector2(100, 100), nameof(WasMeleenaTellingTheTruthAboutWhatHappenedOnRaymondsShip), 
            new MeleenaWasHonest(),
            new MeleenaIsLying()) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(YouBrokeIntoRaymondsShip));
        }
    }
}
