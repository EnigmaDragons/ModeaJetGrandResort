using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Style
{
    public sealed class NoSubView : IJamView
    {
        public ClickUIBranch ClickUiBranch { get; } = new ClickUIBranch("Nothing", 0);

        public void Init()
        {
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Transform2 parentTransform)
        {
        }
    }
}
