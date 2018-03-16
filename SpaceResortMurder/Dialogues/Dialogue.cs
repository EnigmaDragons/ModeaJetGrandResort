using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Text;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues
{
    public abstract class Dialogue
    {
        public string Dialog { get; }

        public bool IsNew => !CurrentGameState.HasViewedItem(Dialog);
        public bool AutoPlay { get; protected set; } = false;

        protected Dialogue(string dialog)
        {
            Dialog = dialog;
        }

        public abstract bool IsActive();

        public void StartImmediateDialog(Action<DialogueElement[]> onStart)
        {
            Event.Publish(new DialogMemoryGained(Dialog, CurrentGameState.CurrentLocationImage));
            Event.Publish(new ThoughtGained(Dialog));
            onStart(GameResources.GetDialogueSequence(Dialog).Elements);
        }

        public VisualClickableUIElement CreateButton(Action<DialogueElement[]> onClick, int i, int count)
        {
            var buttonWidth = 1380;
            var xOff = -684;
            var xInc = 67;
            var yInc = 92;
            var xPos = Math.Max(i * xInc + xOff,(int) DefaultFont.Value.MeasureString(
                GameResources.GetDialogueSequence(Dialog).Opener).X - buttonWidth + 165);
            var yPos = 520 + i * yInc;
            var t = new Transform2(new Vector2(xPos, yPos), new Size2(buttonWidth, 64)).ToRectangle();
            return new ImageTextButton(t, GetOnClick(onClick), GameResources.GetDialogueSequence(Dialog).Opener,
                "Convo/DialogueButton", "Convo/DialogueButton-Hover", "Convo/DialogueButton-Press")
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(50, yPos), Rotation2.Default, new Size2(buttonWidth - xPos, 64), 1.0f),
                TextAlignment = HorizontalAlignment.Left
            };
        }

        private Action GetOnClick(Action<DialogueElement[]> onClick)
        {
            return IsNew
                ? (() =>
                    {
                        Event.Publish(new DialogMemoryGained(Dialog, CurrentGameState.CurrentLocationImage));
                        Event.Publish(new ThoughtGained(Dialog));
                        onClick(GameResources.GetDialogueSequence(Dialog).Elements);
                    })
                : (Action)(() => onClick(GameResources.GetDialogueSequence(Dialog).Elements));
        }
    }
}
