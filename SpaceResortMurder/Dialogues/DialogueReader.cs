﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Text;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.MouseX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues
{
    public class DialogueReader
    {
        private readonly MouseIsClicked _mouseIsClicked = new MouseIsClicked();
        private readonly Queue<DialogueElement> _lines;
        private readonly ChatBox _chatBox;
        private readonly Action _onFinished;
        private readonly Action<DialogueElement> _onAdvance;
        private readonly ImageBox _box;
        private readonly Transform2 _chatBoxTransform;

        public DialogueReader(IEnumerable<DialogueElement> lines, Action onFinished, Action<DialogueElement> onAdvance)
        {
            _chatBox = new ChatBox("", 840, DefaultFont.Value, CurrentOptions.MillisPerTextCharacter, 32);
            _chatBoxTransform = new Transform2(new Vector2(120, 912));
            _lines = new Queue<DialogueElement>(lines);
            _onFinished = onFinished;
            _onAdvance = onAdvance;
            Input.On(Control.A, Advance);
            _box = new ImageBox { Transform = new Transform2(new Size2(1920, 1080)), Image = "Convo/ChatBox" };
            _chatBox.ShowMessage(_lines.Dequeue().Line);
            _onAdvance(lines.First());
        }

        public void Update(TimeSpan delta)
        {
            if (_mouseIsClicked.Evaluate())
                Advance();
            _chatBox.Update(delta);
        }

        public void Draw()
        {
            _box.Draw(Transform2.Zero);
            _chatBox.Draw(_chatBoxTransform);
        }

        private void Advance()
        {
            if (!_chatBox.IsMessageCompletelyDisplayed())
                _chatBox.CompletelyDisplayMessage();
            else if (_lines.Any())
            {
                var element = _lines.Dequeue();
                _onAdvance(element);
                _chatBox.ShowMessage(element.Line);
            }
            else
            {
                Input.On(Control.A, () => { });
                _onFinished();
            }
        }
    }
}
