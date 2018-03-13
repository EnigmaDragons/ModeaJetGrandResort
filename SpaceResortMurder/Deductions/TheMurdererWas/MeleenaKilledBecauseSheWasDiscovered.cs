using SpaceResortMurder.Deductions.MeleenasAccountValidity;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class MeleenaKilledBecauseSheWasDiscovered : Deduction
    {
        public MeleenaKilledBecauseSheWasDiscovered() : base(nameof(MeleenaKilledBecauseSheWasDiscovered)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(MeleenaIsLying));
        }
    }
}
