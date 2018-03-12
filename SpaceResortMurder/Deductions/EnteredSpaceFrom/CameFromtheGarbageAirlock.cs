namespace SpaceResortMurder.Deductions.EnteredSpaceFrom
{ 
    public class CameFromtheGarbageAirlock : Deduction
    {
        public CameFromtheGarbageAirlock() : base(nameof(CameFromtheGarbageAirlock)) {}

        public override bool IsActive()
        {
            return true;
        }
    }
}
