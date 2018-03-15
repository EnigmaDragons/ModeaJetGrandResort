using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Dialogues
{
    public sealed class ConversationView : IJamView
    {
        private readonly Character _person;
        private readonly Action _onFinished;

        private Reader _reader;
        private VisualClickableUIElement _endConversationButton;
        private bool _isPresentingToUser;
        private bool _shouldShowDialogueControls;
        private List<IVisual> _dialogueOptions = new List<IVisual>();

        private IJamView _subView;

        public ClickUIBranch ClickUiBranch { get; } = new ClickUIBranch("Conversation", 1);

        public void Init()
        {
            _subView = new ScanView(_person, DisableDialogueControls, InitDialogueOptions);
            _subView.Init();
            _endConversationButton = new ImageTextButton(new Transform2(new Rectangle(-684, 960, 1380, 77)), _onFinished,
                "Thanks for your help.",
                "Convo/DialogueButton", "Convo/DialogueButton-Hover", "Convo/DialogueButton-Press")
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(60, 960), Rotation2.Default, new Size2(1380 - 684, 77), 1.0f),
                TextAlignment = HorizontalAlignment.Left
            };
            
            if (_person.IsImmediatelyTalking())
                _person.StartImmediatelyTalking(StartDialogue);
            else
                InitDialogueOptions();
        }

        public ConversationView(Character person, Action onFinished)
        {
            _person = person;
            _onFinished = onFinished;
        }

        public void Update(TimeSpan delta)
        {
            _subView.Update(delta);
            if (_isPresentingToUser)
                _reader.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            _person.DrawTalking();

            if (_shouldShowDialogueControls)
            {
                _dialogueOptions.ForEach(x => x.Draw(parentTransform));
                DrawConversationControls(parentTransform);
            }
            if (_isPresentingToUser)
                _reader.Draw();

            _subView.Draw(parentTransform);
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

        private void StartDialogue(string[] lines)
        {
            ClickUiBranch.ClearElements();
            _reader = new Reader(lines, InitDialogueOptions);
            DisableDialogueControls();
            _isPresentingToUser = true;
        }

        private void DisableDialogueControls()
        {
            _shouldShowDialogueControls = false;
        }
    }
}
