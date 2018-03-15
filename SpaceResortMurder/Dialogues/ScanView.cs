using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Animations;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.CharactersX;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Dialogues
{
    public sealed class ScanView : IJamView
    {
        private readonly Character _person;
        private readonly Action _onStarted;
        private readonly Action _onFinished;

        private IVisual _nameDataLabel;
        private ImageTextButton _startScanButton;
        private SinglePositionTraverseAnimation _scanAnimation;
        private bool _startedScanning;
        private bool _isShowingScanData;
        private ScanDataReader _reader;

        public ClickUIBranch ClickUiBranch { get; } = new ClickUIBranch("Scan", 2);

        public ScanView(Character person, Action onStarted, Action onFinished)
        {
            _person = person;
            _onStarted = onStarted;
            _onFinished = onFinished;
        }

        public void Init()
        {
            _nameDataLabel = new Label
            {
                Transform = new Transform2(new Vector2(300, 330), new Size2(500, 75)),
                TextColor = Color.White,
                Text = GameResources.GetCharacterName(_person.Value)
            };
            _startScanButton = new ImageTextButton(new Transform2(new Vector2(1300, 860), new Size2(220, 74)),
                    BeginScan, "Scan", "Convo/ScanButton", "Convo/ScanButton-Hover", "Convo/ScanButton-Press", () => !_startedScanning)
                { TextColor = Color.White };
            _scanAnimation = new SinglePositionTraverseAnimation(
                new ImageBox
                {
                    Image = "Convo/ScanLine",
                    Transform = new Transform2(new Vector2(1200, 400), new Size2(450, 5))
                }, new Vector2(0, 530),
                TimeSpan.FromMilliseconds(1300),
                TimeSpan.FromMilliseconds(0),
                ShowScanData);
            ClickUiBranch.Add(_startScanButton);
        }

        public void Update(TimeSpan delta)
        {
            _scanAnimation.Update(delta);
            if (_isShowingScanData)
                _reader.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            _scanAnimation.Draw(parentTransform);
            if (!_startedScanning)
                _startScanButton.Draw(parentTransform);
            if (_isShowingScanData)
            {
                _reader.Draw();
                _nameDataLabel.Draw();
            }
        }

        private void BeginScan()
        {
            _onStarted();
            Event.Publish(new ThoughtGained(_person.Value));
            Audio.PlaySound("Scanning", 0.3f);
            _scanAnimation.Start();
            _startedScanning = true;
        }

        private void ShowScanData()
        {
            _isShowingScanData = true;
            _reader = new ScanDataReader(new string[] { GameResources.GetScanInfo(_person.Value) }, ScanFinished);
        }

        private void ScanFinished()
        {
            _isShowingScanData = false;
            _onFinished();
        }
    }
}
