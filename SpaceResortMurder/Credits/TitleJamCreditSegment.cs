using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Animations;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Credits
{
    public class TitleJamCreditSegment : IAnimation
    {
        private bool _isStarted;
        private VerticalFlyInAnimation _animation;

        public void Update(TimeSpan delta)
        {
            if (_isStarted)
                _animation.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            if (_isStarted)
                _animation.Draw(parentTransform);
        }

        public void Start(Action onFinished)
        {
            _animation = CreateTitle();
            _animation.Start(onFinished);
            _isStarted = true;
        }

        private VerticalFlyInAnimation CreateTitle()
        {
            var titleImage = new ImageBox { Image = "UI/Title", Transform = new Transform2(new Vector2(UI.OfScreenWidth(0.5f) - 567, UI.OfScreenHeight(0.5f) + 237), new Size2(1134, 474)) };
            titleImage.Transform.Location = new Vector2(titleImage.Transform.Location.X, titleImage.Transform.Location.Y + 800);
            return new VerticalFlyInAnimation(titleImage)
            {
                FromDir = VerticalDirection.Down,
                ToDir = VerticalDirection.Up,
                Drift = 200,
                DurationIn = TimeSpan.FromMilliseconds(200),
                DurationWait = TimeSpan.FromMilliseconds(3000),
                DurationOut = TimeSpan.FromMilliseconds(200)
            };
        }
    }
}
