using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.CharactersX;
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
        private VisualClickableUIElement _endConversationButton;
        private List<IVisual> _dialogueOptions = new List<IVisual>();
        private Player _player = new Player();
        private IJamView _subView;
        private bool _isPresentingToUser;
        private bool _shouldShowDialogueControls;

        public ClickUIBranch ClickUiBranch { get; } = new ClickUIBranch("Conversation", 1);

        public ConversationView(Character person, Action onFinished)
        {
            _person = person;
            _onFinished = onFinished;
        }

        public void Init()
        {
            _subView = new ScanView(_person, DisableDialogueControls, InitDialogueOptions);
            _subView.Init();
            _endConversationButton = new ImageTextButton(new Transform2(new Rectangle(-684, 960, 1380, 77)), _onFinished,
                "Thanks for your help.",
                "Convo/DialogueButton", "Convo/DialogueButton-Hover", "Convo/DialogueButton-Press")
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(60, 960), new Size2(1380 - 684, 77)),
                TextAlignment = HorizontalAlignment.Left
            };
            
            _personName = _person.CreateChatNameBox();

            if (_person.IsImmediatelyTalking())
                _person.StartImmediatelyTalking(StartDialogue);
            else
                InitDialogueOptions();
        }

        public void Update(TimeSpan delta)
        {
            _subView.Update(delta);
            if (_isPresentingToUser)
                _reader.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            if(_shouldShowDialogueControls)
                DrawConversationControls(parentTransform);
            if (_isPresentingToUser)
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
                _subView.Draw(parentTransform);
            }

            _personName.Draw();
            
        }

        private void DrawConversationControls(Transform2 parentTransform)
        {
            _dialogueOptions.ForEach(x => x.Draw());
            _endConversationButton.Draw(parentTransform);
        }

        private void InitDialogueOptions()
        {
            _isPresentingToUser = false;
            _shouldShowDialogueControls = true;
            ClickUiBranch.ClearElements();
            _personName = _person.CreateChatNameBox();
            var newDialogueChoices = new List<IVisual>();
            _person.GetNewDialogs().ForEachIndex((x, i) =>
            {
                var button = x.CreateButton(StartDialogue, i, _person.GetNewDialogs().Count);
                ClickUiBranch.Add(button);
                newDialogueChoices.Add(button);
            });
            ClickUiBranch.Add(_subView.ClickUiBranch);
            ClickUiBranch.Add(_endConversationButton);
            _dialogueOptions = newDialogueChoices;
        }

        private void StartDialogue(DialogueElement[] elements)
        {
            ClickUiBranch.ClearElements();
            ClickUiBranch.Remove(_subView.ClickUiBranch);
            ClickUiBranch.Add(new ScreenClickable(AdvanceChatVisuals));
            _elements = ((IEnumerable<DialogueElement>)elements).GetEnumerator();
            _reader = new Reader(elements.Select(l => l.Line).ToArray(), InitDialogueOptions);
            DisableDialogueControls();
            _isPresentingToUser = true;
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

        private void DisableDialogueControls()
        {
            _shouldShowDialogueControls = false;
        }
    }
}
