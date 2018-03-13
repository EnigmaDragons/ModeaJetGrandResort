using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.MeleenasAccountValidity;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WasMeleenaTellingTheTruthAboutWhatHappenedOnRaymondsShip : Dilemma
    {
        public WasMeleenaTellingTheTruthAboutWhatHappenedOnRaymondsShip() : base(new Vector2(100, 100), nameof(WasMeleenaTellingTheTruthAboutWhatHappenedOnRaymondsShip), 
            new MeleenaWasHonest(),
            new MeleenaIsLying()) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(YouBrokeIntoRaymondsShip));
        }
    }
}
