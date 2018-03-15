using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Clues
{
    public sealed class InvestigateClueView : IJamView
    {
        private readonly Clue _clue;
        private readonly ClueDisplayReader _reader;

        public ClickUIBranch ClickUiBranch { get; } = new ClickUIBranch("Investigate Clue", 3);

        public InvestigateClueView(Clue clue, Action onFinished)
        {
            _clue = clue;
            _reader = new ClueDisplayReader(clue.InvestigationLines, onFinished);
        }

        public void Init()
        {
        }

        public void Update(TimeSpan delta)
        {
            _reader.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            UI.Darken();
            _clue.Draw(parentTransform);
            _reader.Draw();
        }
    }
}
