using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Dialogues;
using System;
using MonoDragons.Core.Graphics;

namespace SpaceResortMurder.CharactersX
{
    public sealed class CharacterView : IVisualAutomaton
    {
        private static readonly BobbingEffect BobbingEffect = new BobbingEffect();

        private readonly Character _character;
        private readonly TintedImageBox _imageBox;
        private readonly IVisual _nameLabel;

        private bool _isSpeaking;

        public CharacterView(Character character, Func<bool> isPlayerSelectingDialogue)
        {
            _character = character;
            _imageBox = new TintedImageBox
            {
                Transform = new Transform2(new Vector2(UI.OfScreenWidth(0.62f), UI.OfScreenHeight(1.0f) - (int)(character.FacingSize.Height / 1.3)), 
                    character.FacingSize),
                Image = GameResources.GetCharacterImage(_character.Value, Expression.Default),
                ShouldTint = () => !_isSpeaking && !isPlayerSelectingDialogue()
            };
            _nameLabel = character.CreateChatNameBox();
        }

        public void UpdateDialogue(DialogueElement current)
        {
            _isSpeaking = current.IsCharacterTalking;
            if (_isSpeaking)
                _imageBox.Image = GameResources.GetCharacterImage(_character.Value, current.Expression);
        }

        public void Draw(Transform2 parentTransform)
        {
            BobbingEffect.Draw(_imageBox, parentTransform);
            _nameLabel.Draw(parentTransform);
        }

        public void Update(TimeSpan delta)
        {
            BobbingEffect.Update(delta);
        }
    }
}
