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

            if (Character != null)
                _elements.Add(Rng.Bool() ? CharacterFromLeft() : CharacterFromRight());
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

            _countdown = _elements.Count;
            _elements.ForEach(x => x.Start(() => FinishedOne(onFinished)));
        }

        private HorizontalFlyInAnimation CharacterFromLeft()
        {
            var characterImage = Character.CreateFacingImage(Expression);
            characterImage.Transform.Location = new Vector2(-1200, characterImage.Transform.Location.Y);
            return new HorizontalFlyInAnimation(characterImage)
            {
                ToDir = HorizontalDirection.Left,
                Drift = 0,
                DurationIn = TimeSpan.FromMilliseconds(100),
                DurationWait = TimeSpan.FromMilliseconds(2300),
                DurationOut = TimeSpan.FromMilliseconds(100)
            };
        }

        private HorizontalFlyInAnimation CharacterFromRight()
        {
            var characterImage = Character.CreateFacingImage(Expression);
            characterImage.Transform.Location = new Vector2(2620, characterImage.Transform.Location.Y);
            return new HorizontalFlyInAnimation(characterImage)
            {
                FromDir = HorizontalDirection.Right,
                ToDir = HorizontalDirection.Right,
                Drift = 0,
                DurationIn = TimeSpan.FromMilliseconds(100),
                DurationWait = TimeSpan.FromMilliseconds(2300),
                DurationOut = TimeSpan.FromMilliseconds(100)
            };
        }

        private void FinishedOne(Action onFinished)
        {
            _countdown--;
            if (_countdown == 0)
                onFinished();
        }
    }
}
