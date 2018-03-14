using System;
using System.Collections.Generic;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.TutorialsX
{
    public sealed class Tutorials : IVisualAutomaton
    {
        private readonly List<IVisualAutomaton> _tutorials = new List<IVisualAutomaton>();

        public void Init()
        {
            _tutorials.Add(new ObjectivesTutorial());
        }

        public void Update(TimeSpan delta)
        {
            _tutorials.ForEach(x => x.Update(delta));
        }

        public void Draw(Transform2 parentTransform)
        {
            _tutorials.ForEach(x => x.Draw(parentTransform));
        }
    }
}
