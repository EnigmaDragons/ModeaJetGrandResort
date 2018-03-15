using SpaceResortMurder.CharactersX;

namespace SpaceResortMurder.Dialogues
{
    public class DialogueElement
    {
        public bool IsCharacterTalking { get; }
        public Expression Expression { get; }
        public string Line { get; }

        public DialogueElement(bool isCharacterTalking, string line) : this(isCharacterTalking, Expression.Default, line) { }

        public DialogueElement(bool isCharacterTalking, Expression expression, string line)
        {
            IsCharacterTalking = isCharacterTalking;
            Expression = expression;
            Line = line;
        }
    }
}