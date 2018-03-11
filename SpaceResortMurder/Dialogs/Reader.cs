using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Text;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.MouseX;

namespace SpaceResortMurder.Dialogs
{
    public class Reader
    {
        private readonly MouseIsClicked _mouseIsClicked = new MouseIsClicked();
        private readonly Queue<string> _lines;
        private readonly ChatBox _chatBox;
        private readonly Action _onFinished;
        private readonly ImageBox _box;
        private readonly Transform2 _chatBoxTransform;

        public Reader(string[] linesToBeRead, Action onFinished)
        {
            _chatBox = new ChatBox("", 1500, DefaultFont.Font);
            _chatBoxTransform = new Transform2(new Vector2(100, 623));
            _lines = new Queue<string>(linesToBeRead);
            _onFinished = onFinished;
            Input.On(Control.A, Advance);
            _box = new ImageBox { Transform = new Transform2(new Vector2(0, 523), new Size2(1600, 377)), Image = "Placeholder/dialoguebox" };
            _chatBox.ShowMessage(_lines.Dequeue());
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
                _chatBox.ShowMessage(_lines.Dequeue());
            else
            {
                Input.On(Control.A, () => {});
                _onFinished();
            }
        }
    }
}
