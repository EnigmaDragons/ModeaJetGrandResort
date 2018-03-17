using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Dialogues;
using System;
using System.Collections.Generic;
using MonoDragons.Core.Graphics;

namespace SpaceResortMurder.CharactersX
{
    public sealed class PlayerCharacterView : IVisualAutomaton
    {
        private static readonly BobbingEffect BobbingEffect = new BobbingEffect();

        private readonly DictionaryWithDefault<Expression, string> _images = new DictionaryWithDefault<Expression, string>("characters/main_character")
        {
            { Expression.Default,"characters/main_character" },
            { Expression.Angry, "characters/main_character_angry" },
        };

        private readonly TintedImageBox _imageBox;

        private bool _isSpeaking;

        public PlayerCharacterView(Func<bool> isSelectingDialogue)
        {
            _imageBox = new TintedImageBox
            {
                Transform = new Transform2(new Vector2(UI.OfScreenWidth(0), UI.OfScreenHeight(1.0f) - (int)(1200 / 1.3)), new Size2(490, 1200)),
                Image = "characters/main_character",
                ShouldTint = () => !_isSpeaking && !isSelectingDialogue()
            };
        }

        public void UpdateDialogue(DialogueElement current)
        {
            _isSpeaking = !current.IsCharacterTalking;
            if (_isSpeaking)
                _imageBox.Image = _images[current.Expression];
        }

        public void Draw(Transform2 parentTransform)
        {
            BobbingEffect.Draw(_imageBox, parentTransform);
        }

        public void Update(TimeSpan delta)
        {
            BobbingEffect.Update(delta);
        }
    }
}
