using System;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Dialogs;
using SpaceResortMurder.CharactersX;
using MonoDragons.Core.Engine;
using System.Collections.Generic;
using MonoDragons.Core.Common;
using Microsoft.Xna.Framework;

namespace SpaceResortMurder
{
    public class DialogMemoriesScene : IScene
    {
        private bool _isInTheMiddleOfDialog;
        private ClickUI _clickUI;
        private ClickUIBranch _memoriesBranch;
        private Reader _reader;
        private Character _talkingTo;
        private List<IVisual> _dialogOptions;

        public void Init()
        {
            _clickUI = new ClickUI();
            _clickUI.Add(GameObjects.Hud.HudBranch);
            _memoriesBranch = new ClickUIBranch("Memories", 1);
            _clickUI.Add(_memoriesBranch);
            _isInTheMiddleOfDialog = false;
            _dialogOptions = new List<IVisual>();
            foreach (var person in GameObjects.Characters.People)
                foreach(var dialog in person.GetOldDialogs())
                {
                    var button = dialog.CreateButton((x) => RememberDialog(person, x), 0, 0);
                    button.Offset = new Vector2(0, -300 + _dialogOptions.Count * 100);
                    _memoriesBranch.Add(button);
                    _dialogOptions.Add(button);
                }
        }

        private void RememberDialog(Character character, string[] lines)
        {
            _talkingTo = character;
            _clickUI.Remove(_memoriesBranch);
            _clickUI.Remove(GameObjects.Hud.HudBranch);
            _reader = new Reader(lines, EndMemory);
            _isInTheMiddleOfDialog = true;
        }

        private void EndMemory()
        {
            _isInTheMiddleOfDialog = false;
            _clickUI.Add(GameObjects.Hud.HudBranch);
            _clickUI.Add(_memoriesBranch);
        }

        public void Draw()
        {
            if (_isInTheMiddleOfDialog)
            {
                _talkingTo.DrawTalking();
                _reader.Draw();
                
            }
            else
            {
                _dialogOptions.ForEachIndex((d, i) => d.Draw(new Transform2(new Vector2(0, -300 + i * 100))));
                GameObjects.Hud.Draw(Transform2.Zero);
            }
        }
        
        public void Update(TimeSpan delta)
        {
            if (_isInTheMiddleOfDialog)
                _reader.Update(delta);
            _clickUI.Update(delta);
        }

        public void Dispose()
        {
            _clickUI.Dispose();
        }
    }
}