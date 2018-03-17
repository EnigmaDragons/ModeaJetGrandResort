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
using MonoDragons.Core.EventSystem;
using SpaceResortMurder.State;
using SpaceResortMurder.TutorialsX;

namespace SpaceResortMurder.Dialogues
{
    public sealed class ConversationView : IJamView
    {
        private readonly Character _person;
        private readonly Action _onFinished;

        private ExclusiveChoicesTutorial _tutorial;
        private DialogueReader _reader;
        private VisualClickableUIElement _endConversationButton;
        private List<IVisual> _dialogueOptions = new List<IVisual>();
        
        private PlayerCharacterView _playerView;
        private CharacterView _characterView;

        private IJamView _subView;
        private bool _isPresentingToUser;
        private bool _shouldShowDialogueControls;
        private Action<DialogueElement> _onNextDialogueElement;

        public ClickUIBranch ClickUiBranch { get; } = new ClickUIBranch("Conversation", 1);

        public ConversationView(Character person, Action onFinished)
        {
            _person = person;
            _onFinished = onFinished;
        }

        public void Init()
        {
            _tutorial = new ExclusiveChoicesTutorial();
            _subView = new ScanView(_person, DisableDialogueControls, InitDialogueOptions, () => !_isPresentingToUser);
            _subView.Init();
            _endConversationButton = new ImageTextButton(new Transform2(new Rectangle(-684, 960, 1380, 64)), _onFinished,
                "Ok, great.",
                "Convo/DialogueButton", "Convo/DialogueButton-Hover", "Convo/DialogueButton-Press")
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(60, 960), new Size2(1380 - 684, 64)),
                TextAlignment = HorizontalAlignment.Left
            };
            
            _characterView = new CharacterView(_person, () => _shouldShowDialogueControls);
            _playerView = new PlayerCharacterView(() => _shouldShowDialogueControls);

            _onNextDialogueElement = x => {
                _characterView.UpdateDialogue(x);
                _playerView.UpdateDialogue(x);
            };

            if (_person.IsImmediatelyTalking())
                _person.StartImmediatelyTalking(StartDialogue);
            else
                InitDialogueOptions();
        }

        public void Update(TimeSpan delta)
        {
            _tutorial.Update(delta);
            _playerView.Update(delta);
            _characterView.Update(delta);
            _subView.Update(delta);
            if (_isPresentingToUser)
                _reader.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            _playerView.Draw(parentTransform);
            _characterView.Draw(parentTransform);

            if (_shouldShowDialogueControls)
                DrawConversationControls(parentTransform);

            if (_isPresentingToUser)
                _reader.Draw();

            _subView.Draw(parentTransform);
            _tutorial.Draw(parentTransform);
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
            ClickUiBranch.Clear();
            var newDialogueChoices = new List<IVisual>();
            _person.GetNewDialogs().Take(4).ForEachIndex((x, i) =>
            {
                var button = x.CreateButton(StartDialogue, i, _person.GetNewDialogs().Count);
                ClickUiBranch.Add(button);
                newDialogueChoices.Add(button);
                if (x.IsExclusive && !CurrentGameState.HasViewedItem(nameof(ExclusiveChoicesTutorial)))
                    Event.Publish(new ItemViewed(GameResources.WhatAreExclusiveChoices));
            });

            ClickUiBranch.Add(_tutorial.Button);
            ClickUiBranch.Add(_subView.ClickUiBranch);
            ClickUiBranch.Add(_endConversationButton);
            _dialogueOptions = newDialogueChoices;
        }

        private void StartDialogue(DialogueElement[] elements)
        {
            ClickUiBranch.Clear();
            _reader = new DialogueReader(elements, InitDialogueOptions, _onNextDialogueElement);
            DisableDialogueControls();
            _isPresentingToUser = true;
        }

        private void DisableDialogueControls()
        {
            _shouldShowDialogueControls = false;
        }
    }
}
