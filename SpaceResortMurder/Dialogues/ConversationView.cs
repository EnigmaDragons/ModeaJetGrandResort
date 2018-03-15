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

namespace SpaceResortMurder.Dialogues
{
    public sealed class ConversationView : IJamView
    {
        private readonly Character _person;
        private readonly Action _onFinished;

        private Reader _reader;
        private VisualClickableUIElement _scan;
        private VisualClickableUIElement _endConversationButton;
        private bool _isInTheMiddleOfDialogue;
        private List<IVisual> _dialogueOptions = new List<IVisual>();

        public ClickUIBranch ClickUiBranch { get; } = new ClickUIBranch("Conversation", 1);

        public void Init()
        {
            _endConversationButton = new ImageTextButton(new Transform2(new Rectangle(-684, 960, 1380, 77)), _onFinished,
                "Thanks for your help.",
                "Convo/DialogueButton", "Convo/DialogueButton-Hover", "Convo/DialogueButton-Press")
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(60, 960), Rotation2.Default, new Size2(1380 - 684, 77), 1.0f),
                TextAlignment = HorizontalAlignment.Left
            };

            _scan = UiButtons.MenuRed("Scan", new Vector2(816, 1000), () =>
            {
                Event.Publish(new ThoughtGained(_person.Value));
                // TODO: Replace this with Scan feature
                StartDialogue(GameResources.GetDialogueLines(_person.Value));
            });
            
            if (_person.IsImmediatelyTalking())
                _person.StartImmediatelyTalking(StartDialogue);
            else
                StartTalking();
        }

        public ConversationView(Character person, Action onFinished)
        {
            _person = person;
            _onFinished = onFinished;
        }

        public void Update(TimeSpan delta)
        {
            if (_isInTheMiddleOfDialogue)
                _reader.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            _dialogueOptions.ForEach(x => x.Draw(parentTransform));
            _person.DrawTalking();
            if (_isInTheMiddleOfDialogue)
                _reader.Draw();
            else
                DrawConversationControls(parentTransform);
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
            _isInTheMiddleOfDialogue = false;
            StartTalking();
        }

        private void StartDialogue(string[] lines)
        {
            ClickUiBranch.ClearElements();
            _reader = new Reader(lines, EndDialogue);
            _isInTheMiddleOfDialogue = true;
        }
    }
}
