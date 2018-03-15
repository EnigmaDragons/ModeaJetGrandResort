namespace SpaceResortMurder.Dialogues
{
    public class DialogueSequence
    {
        public string Opener { get; }
        public DialogueElement[] Elements { get; }

        public DialogueSequence(string opener, params DialogueElement[] elements)
        {
            Opener = opener;
            Elements = elements;
        }
    }
}
