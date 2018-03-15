﻿using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.Animations
{
    public sealed class SinglePositionTraverseAnimation : IVisualAutomaton
    {
        private readonly IVisual _visual;
        private readonly Vector2 _moveBy;
        private readonly TimeSpan _movementDuration;
        private readonly Action _onFinished;
        private readonly TimeSpan _totalDuration;

        private bool _started;
        private TimeSpan _elapsed = TimeSpan.Zero;
        private Vector2 _currentPosition;

        public SinglePositionTraverseAnimation(IVisual visual, Vector2 moveBy, TimeSpan movementDuration, TimeSpan stayDuration, Action onFinished)
        {
            _visual = visual;
            _moveBy = moveBy;
            _movementDuration = movementDuration;
            _onFinished = onFinished;
            _totalDuration = _movementDuration + stayDuration;
        }

        public void Start()
        {
            _started = true;
        }

        public void Update(TimeSpan delta)
        {
            IfRunning(() =>
            {
                _elapsed += delta;
                _currentPosition = _elapsed >= _movementDuration
                    ? _moveBy
                    : Vector2.Lerp(Vector2.Zero, _moveBy, (float)_elapsed.TotalMilliseconds / (float)_movementDuration.TotalMilliseconds);
                if (_elapsed >= _totalDuration)
                    _onFinished();
            });
        }

        public void Draw(Transform2 parentTransform)
        {
            IfRunning(() => _visual.Draw(new Transform2(_currentPosition)));
        }

        private void IfRunning(Action action)
        {
            if (_started && _elapsed <= _totalDuration)
                action();
        }
    }
}
