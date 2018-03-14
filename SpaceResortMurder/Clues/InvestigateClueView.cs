using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Clues
{
    public sealed class InvestigateClueView : IVisualAutomaton
    {
        private readonly Clue _clue;
        private readonly ClueDisplayReader _reader;

        public InvestigateClueView(Clue clue, Action onFinished)
        {
            _clue = clue;
            _reader = new ClueDisplayReader(clue.InvestigationLines, onFinished);
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
