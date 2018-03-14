using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogues;

namespace SpaceResortMurder.Clues
{
    public sealed class InvestigateClueView : IVisualAutomaton
    {
        private readonly Clue _clue;
        private readonly Reader _reader;

        public InvestigateClueView(Clue clue, Action onFinished)
        {
            _clue = clue;
            _reader = new Reader(clue.InvestigationLines, onFinished);
        }

        public void Update(TimeSpan delta)
        {
            _reader.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            _clue.FacingImage.Draw(parentTransform);
            _reader.Draw();
        }
    }
}
