using System.Collections.Generic;
using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.PhysicsEngine;
using Microsoft.Xna.Framework;
using SpaceResortMurder.Dialogues;

namespace SpaceResortMurder.CharactersX
{
    public sealed class PlayerCharacter : IVisual
    {
        private readonly Transform2 _transform = new Transform2(new Vector2(UI.OfScreenWidth(0), UI.OfScreenHeight(1.0f) - (int) (1200 / 1.3)), new Size2(490, 1200));

        private readonly Dictionary<Expression, IVisual> _images;

        public PlayerCharacter()
        {
            _images = new Dictionary<Expression, IVisual>
            {
                {
                    Expression.Default,
                    new ImageBox { Transform = _transform, Image = "characters/main_character" }
                },
                {
                    Expression.Angry,
                    new ImageBox { Transform = _transform, Image = "characters/main_character_angry" }
                },
            };
        }

        private Expression _expression = Expression.Default;
        private bool _isSpeaking;

        public void Update(DialogueElement current)
        {
            _isSpeaking = !current.IsCharacterTalking;
            if (_isSpeaking)
                _expression = current.Expression;
        }

        public void Draw(Transform2 parentTransform)
        {
            GetImage(_expression).Draw(parentTransform);
        }

        private IVisual GetImage(Expression expression = Expression.Default)
        {
            return _images[expression];
        }
    }
}
