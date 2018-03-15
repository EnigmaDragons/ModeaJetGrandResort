using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.CharactersX;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;
using System.Linq;

namespace SpaceResortMurder.Dialogues
{
    public sealed class ConversationView : IJamView
    {
        private readonly Character _person;
        private readonly Action _onFinished;

        private Reader _reader;
        private IVisual _personImage;
        private IVisual _personName;
        private IVisual _playerImage;
        private IEnumerator<DialogueElement> _elements;
        private bool _isCharacterTalking;
        private VisualClickableUIElement _scan;
        private VisualClickableUIElement _endConversationButton;
        private bool _isInTheMiddleOfDialogue;
        private List<IVisual> _dialogueOptions = new List<IVisual>();
        private Player _player = new Player();

        public ClickUIBranch ClickUiBranch { get; } = new ClickUIBranch("Conversation", 1);

        public ConversationView(Character person, Action onFinished)
        {
            _person = person;
            _onFinished = onFinished;
        }

        public void Init()
        {
            _endConversationButton = new ImageTextButton(new Transform2(new Rectangle(-684, 960, 1380, 77)), _onFinished,
                "Thanks for your help.",
                "Convo/DialogueButton", "Convo/DialogueButton-Hover", "Convo/DialogueButton-Press")
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(60, 960), new Size2(1380 - 684, 77)),
                TextAlignment = HorizontalAlignment.Left
            };

            _scan = UiButtons.MenuRed("Scan", new Vector2(816, 1000), () =>
            {
                Event.Publish(new ThoughtGained(_person.Value));
                // TODO: Replace this with Scan feature
                Scan(new string[] { "This isn't implemented in this version" });
            });
            _personName = _person.CreateChatNameBox();

            if (_person.IsImmediatelyTalking())
                _person.StartImmediatelyTalking(StartDialogue);
            else
                StartTalking();
        }

        public void Update(TimeSpan delta)
        {
            if (_isInTheMiddleOfDialogue)
                _reader.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            if (_isInTheMiddleOfDialogue)
            {
                if (_isCharacterTalking)
                    _personImage.Draw();
                else
                    _playerImage.Draw();
                _reader.Draw();
            }
            else
            {
                _person.FacingImage.Draw();
                DrawConversationControls(parentTransform);
            }
            _personName.Draw();
        }

        private void DrawConversationControls(Transform2 parentTransform)
        {
            _dialogueOptions.ForEach(x => x.Draw());
            _endConversationButton.Draw(parentTransform);
            _scan.Draw();
        }

        private void StartTalking()
        {
            var newDialogueChoices = new List<IVisual>();
            _person.GetNewDialogs().ForEachIndex((x, i) =>
            {
                var button = x.CreateButton(StartDialogue, i, _person.GetNewDialogs().Count);
                ClickUiBranch.Add(button);
                newDialogueChoices.Add(button);
            });
            ClickUiBranch.Add(_scan);
            ClickUiBranch.Add(_endConversationButton);
            _dialogueOptions = newDialogueChoices;
        }

        private void EndDialogue()
        {
            ClickUiBranch.ClearElements();
            _isInTheMiddleOfDialogue = false;
            _personName = _person.CreateChatNameBox();
            StartTalking();
        }

        private void StartDialogue(DialogueElement[] elements)
        {
            ClickUiBranch.ClearElements();
            ClickUiBranch.Add(new ScreenClickable(AdvanceChatVisuals));
            _elements = ((IEnumerable<DialogueElement>)elements).GetEnumerator();
            _reader = new Reader(elements.Select(l => l.Line).ToArray(), EndDialogue);
            _isInTheMiddleOfDialogue = true;
            _personImage = _person.GetFacingImage();
            _playerImage = _player.GetImage();
            AdvanceChatVisuals();
        }

        private void AdvanceChatVisuals()
        {
            if (_elements.MoveNext())
            {
                _isCharacterTalking = _elements.Current.IsCharacterTalking;
                if (_isCharacterTalking)
                    _personImage = _person.CreateFacingImage(_elements.Current.Expression);
                else
                    _playerImage = _player.GetImage(_elements.Current.Expression);
            }
        }

        private void Scan(string[] lines)
        {
            ClickUiBranch.ClearElements();
            _reader = new Reader(lines, EndDialogue);
            _isInTheMiddleOfDialogue = true;
        }
    }
}
