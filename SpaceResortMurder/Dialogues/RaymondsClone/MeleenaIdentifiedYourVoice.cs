using SpaceResortMurder.Deductions.MeleenasAccountValidity;
using SpaceResortMurder.Dialogues.Meleena;

namespace SpaceResortMurder.Dialogues.RaymondsClone
{
    public class MeleenaIdentifiedYourVoice : Dialogue
    {
        public MeleenaIdentifiedYourVoice() : base(nameof(MeleenaIdentifiedYourVoice)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenaWasHonest))
                   && GameState.Instance.IsThinking(nameof(MeleenaHeardRaymondsVoice));
        }
    }
}
