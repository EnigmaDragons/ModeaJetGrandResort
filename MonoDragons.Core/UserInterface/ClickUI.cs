﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Engine;
using System.Linq;
using MonoDragons.Core.Render;

namespace MonoDragons.Core.UserInterface
{
    public sealed class ClickUI : IAutomaton, IDisposable
    {
        public static readonly ClickableUIElement None = new NoneClickableUIElement();

        private List<ClickUIBranch> _branches = new List<ClickUIBranch> { new ClickUIBranch("Base", 0) };
        
        private float Scale => CurrentDisplay.Scale;
        
        private ClickableUIElement _current = None;
        private bool _wasClicked;
        private ClickUIBranch _elementLayer;
        private readonly Action<ClickUIBranch>[] subscribeAction;

        public ClickUI()
        {
            _elementLayer = _branches[0];
            subscribeAction = new Action<ClickUIBranch>[] { Add, Remove }; ;
        }

        public void Add(ClickUIBranch branch)
        {
            var branches = GetAllBranchesFrom(branch);
            foreach (var b in branches)
            {
                _branches.Add(b);
                b.Subscribe(subscribeAction);
            }
            _branches = _branches.OrderBy((b) => b.Priority).Reverse().ToList();
        }

        private List<ClickUIBranch> GetAllBranchesFrom(ClickUIBranch branch)
        {
            var branches = new List<ClickUIBranch> { branch };
            foreach (ClickUIBranch subBranch in branch.SubBranches())
                branches.AddRange(GetAllBranchesFrom(subBranch));
            return branches;
        }

        public void Add(ClickableUIElement element)
        {
            _elementLayer.Add(element);
        }

        public void Remove(ClickUIBranch branch)
        {
            var branches = GetAllBranchesFrom(branch);
            foreach (var b in branches)
            {
                _branches.Remove(b);
                b.Unsubscribe(subscribeAction);
                if (b.IsCurrentElement(_current) && _current.IsHovered)
                {
                    _current.OnExitted();
                    _current.IsHovered = false;
                }
            }
        }

        public void Remove(ClickableUIElement element)
        {
            _elementLayer.Remove(element);
        }

        public void Update(TimeSpan delta)
        {
            var mouse = Mouse.GetState();
            if (CurrentGame.TheGame.IsActive)
            {
                var newElement = GetElement(mouse);
                if (newElement != _current)
                    ChangeActiveElement(newElement);
                else if (MouseIsOutOfGame(mouse))
                    return;
                else if (WasMouseReleased(mouse))
                    OnReleased(mouse);
                else if (mouse.LeftButton == ButtonState.Pressed)
                    OnPressed();
            }
        }

        private bool MouseIsOutOfGame(MouseState mouse)
        {
            return mouse.Position.X < 0 || mouse.Position.X > CurrentDisplay.GameWidth 
                || mouse.Position.Y < 0 || mouse.Position.Y > CurrentDisplay.GameHeight;
        }

        private void OnPressed()
        {
            if (_wasClicked)
                return;

            _current.OnPressed();
            _wasClicked = true;
        }

        private void OnReleased(MouseState mouse)
        {
            _current.OnReleased();
            _wasClicked = false;
            if(_current == GetElement(mouse))
                _current.OnEntered();
        }

        private void ChangeActiveElement(ClickableUIElement newElement)
        {
            if (_current.IsHovered)
            {
                _current.OnExitted();
                _current.IsHovered = false;
            }
            _wasClicked = false;
            _current = newElement;
            _current.OnEntered();
            _current.IsHovered = true;
        }

        private bool WasMouseReleased(MouseState mouse)
        {
            return _wasClicked && WasReleased(mouse) && IsSameElement(mouse);
        }

        private bool IsSameElement(MouseState mouse)
        {
            return ReferenceEquals(_current, GetElement(mouse));
        }

        private static bool WasReleased(MouseState mouse)
        {
            return mouse.LeftButton == ButtonState.Released;
        }

        private ClickableUIElement GetElement(MouseState mouse)
        {
            var position = ScaleMousePosition(mouse);
            var branch = _branches.Find((b) => b.GetElement(position) != None);
            return branch != null ? branch.GetElement(position) : None;
        }

        private Point ScaleMousePosition(MouseState mouse)
        {
            return new Point((int)Math.Round(mouse.Position.X / Scale), (int)Math.Round(mouse.Position.Y / Scale));
        }

        public void Dispose()
        {
            if (_current.IsHovered)
                _current.OnExitted();
            _current = None;
        }
    }
}
