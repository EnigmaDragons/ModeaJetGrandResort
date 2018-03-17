using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Animations;
using MonoDragons.Core.Common;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Style;
using SpaceResortMurder.CharactersX;

namespace SpaceResortMurder.Credits
{
    public abstract class BasicJamCreditSegment : IAnimation
    {
        private readonly List<HorizontalFlyInAnimation> _elements = new List<HorizontalFlyInAnimation>();
        
        private int _countdown;

        public abstract Character Character { get; }
        public abstract Expression Expression { get; }
        public abstract string Role { get; }
        public abstract string Name { get; }

        public void Update(TimeSpan delta)
        {
            _elements.ForEach(x => x.Update(delta));
        }

        public void Draw(Transform2 parentTransform)
        {
            _elements.ForEach(x => x.Draw(parentTransform));
        }

        public void Start(Action onFinished)
        {
            var yStart = Rng.Int(280, 800);
            _elements.Add(new HorizontalFlyInAnimation(
                new Label
                {
                    TextColor = UiStyle.TextGreen, Text = Role,
                    Transform = new Transform2(new Vector2(-800, yStart), new Size2(800, 100)),
                    Font = UiFonts.Header
                }));
            _elements.Add(new HorizontalFlyInAnimation(
                new Label
                    {
                        Text = Name,
                        Transform = new Transform2(new Vector2(1920, yStart + 135), new Size2(800, 75))
                    })
                { FromDir = HorizontalDirection.Right, ToDir = HorizontalDirection.Left });
            var characterImage = Character.CreateFacingImage(Expression);
            characterImage.Transform.Location = new Vector2(-500, yStart + 200);
            characterImage.Transform.Size /= 3;
            _elements.Add(new HorizontalFlyInAnimation(characterImage));

            _countdown = _elements.Count;
            _elements.ForEach(x => x.Start(() => FinishedOne(onFinished)));
        }

        private void FinishedOne(Action onFinished)
        {
            _countdown--;
            if (_countdown == 0)
                onFinished();
        }
    }
}
