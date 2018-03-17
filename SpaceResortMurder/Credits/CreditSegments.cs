using SpaceResortMurder.CharactersX;

namespace SpaceResortMurder.Credits
{
    public sealed class EnigmaDragonsCredit : BasicJamCreditSegment
    {
        public override Character Character => GameObjects.Characters.GetCharacter<CEORaymondsClone>();
        public override Expression Expression => Expression.Default;
        public override string Role => "Enigma Dragons";
        public override string Name => "";

    }

    public sealed class ProjectManagerCredit : BasicJamCreditSegment
    {
        public override Character Character => GameObjects.Characters.GetCharacter<ResearcherTravis>();
        public override Expression Expression => Expression.Thinking;
        public override string Role => "Project Manager";
        public override string Name => "Silas Reinagel";
    }

    public sealed class LeadArtistCredit : BasicJamCreditSegment
    {
        public override Character Character => GameObjects.Characters.GetCharacter<ResortManagerZaid>();
        public override Expression Expression => Expression.Angry;
        public override string Role => "Lead Artist";
        public override string Name => "Lucas Fernandes";
    }

    public sealed class UiDesignerCredit : BasicJamCreditSegment
    {
        public override Character Character => GameObjects.Characters.GetCharacter<ResearcherTravis>();
        public override Expression Expression => Expression.Angry;
        public override string Role => "UI Designer";
        public override string Name => "Silas Reinagel";
    }

    public sealed class GameDesignerCredit : BasicJamCreditSegment
    {
        public override Character Character => GameObjects.Characters.GetCharacter<HackerMeleena>();
        public override Expression Expression => Expression.Happy;
        public override string Role => "Game Designer";
        public override string Name => "Noah Reinagel";
    }

    public sealed class ComposerCredit : BasicJamCreditSegment
    {
        public override Character Character => GameObjects.Characters.GetCharacter<ResearcherTravis>();
        public override Expression Expression => Expression.Happy;
        public override string Role => "Music Composer";
        public override string Name => "Silas Reinagel";
    }

    public sealed class WriterCredit : BasicJamCreditSegment
    {
        public override Character Character => GameObjects.Characters.GetCharacter<HackerMeleena>();
        public override Expression Expression => Expression.Angry;
        public override string Role => "Story & Dialogue Writer";
        public override string Name => "Noah Reinagel";
    }

    public sealed class ProgrammerCredit : BasicJamCreditSegment
    {
        public override Character Character => GameObjects.Characters.GetCharacter<OfficerWarren>();
        public override Expression Expression => Expression.Default;
        public override string Role => "Lead Programmer";
        public override string Name => "Tim Reinagel";
    }

    public sealed class CharacterArtistCredit : BasicJamCreditSegment
    {
        public override Character Character => GameObjects.Characters.GetCharacter<ResortManagerZaid>();
        public override Expression Expression => Expression.Happy;
        public override string Role => "Character Artist";
        public override string Name => "Lucas Fernandes";
    }

    public sealed class EnvironmentArtPaintingCredit : BasicJamCreditSegment
    {
        public override Character Character => GameObjects.Characters.GetCharacter<ResortManagerZaid>();
        public override Expression Expression => Expression.Angry;
        public override string Role => "Environment Art Painting";
        public override string Name => "Lucas Fernandes";
    }

    public sealed class EnvironmentArtConceptsCredit : BasicJamCreditSegment
    {
        public override Character Character => GameObjects.Characters.GetCharacter<CEORaymondsClone>();
        public override Expression Expression => Expression.Default;
        public override string Role => "Environment Art Concepts";
        public override string Name => "Sylvester Grant";
    }
}
