using Microsoft.Xna.Framework;
using SpaceResortMurder.Deductions.VictimsIdentity;
using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.State;

namespace SpaceResortMurder.DilemmasX
{
    public class WhoIsTheVictim : Dilemma
    {
        public WhoIsTheVictim() : base(new Vector2(620, 510), nameof(WhoIsTheVictim), 
            new TheVictimIsRaymond(),
            new TheVictimIsRaymondsClone()) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(MeetingRaymondsClone));
        }
    }
}
