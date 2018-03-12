using SpaceResortMurder.Deductions.MeleenasAccountValidity;

namespace SpaceResortMurder.Deductions.TheMurdererWas
{
    public class MeleenaKilledBecauseSheWasDiscovered : Deduction
    {
        public MeleenaKilledBecauseSheWasDiscovered() : base(nameof(MeleenaKilledBecauseSheWasDiscovered)) {}

        public override bool IsActive()
        {
            return GameState.Instance.IsThinking(nameof(MeleenaIsLying));
        }
    }
}
