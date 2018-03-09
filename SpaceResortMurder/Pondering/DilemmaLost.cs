namespace SpaceResortMurder.Pondering
{
    public class DilemmaLost
    {
        public IDilemma Dilemma { get; }

        public DilemmaLost(IDilemma dilemma)
        {
            Dilemma = dilemma;
        }
    }
}
