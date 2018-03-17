using System;
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
    public class ScanDataReader
    {
        private readonly MouseIsClicked _mouseIsClicked = new MouseIsClicked();
        private readonly Queue<string> _lines;
        private readonly ChatBox _chatBox;
        private readonly Action _onFinished;
        private readonly ImageBox _box;
        private readonly Transform2 _chatBoxTransform;

        public ScanDataReader(string[] linesToBeRead, Action onFinished)
        {
            _chatBox = new ChatBox("", 630, DefaultFont.Value, CurrentOptions.MillisPerTextCharacter, 32) { SoundsEnabled = false };
            _chatBoxTransform = new Transform2(new Vector2(260, 450));
            _lines = new Queue<string>(linesToBeRead);
            _onFinished = onFinished;
            Input.On(Control.A, Advance);
            _box = new ImageBox { Transform = new Transform2(new Vector2(0, 0), new Size2(1920, 1080)), Image = "Convo/ScanDataView" };
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
