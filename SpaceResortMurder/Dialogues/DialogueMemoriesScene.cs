using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.CharactersX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues
{
    public class DialogueMemoriesScene : IScene
    {
        private bool _isInTheMiddleOfDialog = false;
        private ClickUI _clickUI;
        private ClickUIBranch _personMemoriesBranch;
        private ClickUIBranch _dialogMemoriesBranch;
        private Reader _reader;
        private Character _selectedPerson;
        private List<IVisual> _characterOptions;
        private List<IVisual> _dialogOptions = new List<IVisual>();
        private string _locationMemory;
        private IVisual _personImage;
        private PlayerCharacterView _player;
        private ClickableUIElement _dialogueAdvancer;
        private bool _isCharacterTalking;
        private IVisual _personName;
        private IEnumerator<DialogueElement> _elements;

        public void Init()
        {
            _player = new PlayerCharacterView(() => !_isInTheMiddleOfDialog);
            _dialogueAdvancer = new ScreenClickable(AdvanceChatVisuals);
            _clickUI = new ClickUI();
            _clickUI.Add(GameObjects.Hud.HudBranch);
            _personMemoriesBranch = new ClickUIBranch("People", 1);
            _clickUI.Add(_personMemoriesBranch);
            _dialogMemoriesBranch = new ClickUIBranch("Dialogs", 1);
            _clickUI.Add(_dialogMemoriesBranch);
            _characterOptions = new List<IVisual>();
            var people = GameObjects.Characters.People.Where(p => p.GetOldDialogs().Count != 0);
            people.ForEachIndex((p, i) =>
            {
                var button = p.CreateButton(RememberDialogsWithPerson, i, people.Count());
                _characterOptions.Add(button);
                _personMemoriesBranch.Add(button);
            });
        }

        private void RememberDialogsWithPerson(Character person)
        {
            _selectedPerson = person;
            _dialogOptions = new List<IVisual>();
            _dialogMemoriesBranch.ClearElements();
            foreach (var dialog in person.GetOldDialogs())
            {
                var button = dialog.CreateButton((l) => RememberDialog(dialog.Dialog, l), 0, 0);
                button.Offset = new Vector2(0, -300 + _dialogOptions.Count * 100);
                _dialogMemoriesBranch.Add(button);
                _dialogOptions.Add(button);
            }
        }

        private void RememberDialog(string dialog, DialogueElement[] elements)
        {
            _personName = _selectedPerson.CreateChatNameBox();
            _elements = ((IEnumerable<DialogueElement>)elements).GetEnumerator();
            _locationMemory = CurrentGameState.RememberLocation(dialog);
            _clickUI.Remove(_dialogMemoriesBranch);
            _clickUI.Remove(_personMemoriesBranch);
            _clickUI.Remove(GameObjects.Hud.HudBranch);
            _clickUI.Add(_dialogueAdvancer);
            _personImage = _selectedPerson.CreateFacingImage(Expression.Default);
            _reader = new Reader(elements.Select(e => e.Line).ToArray(), EndMemory);
            _isInTheMiddleOfDialog = true;
            AdvanceChatVisuals();
        }

        private void AdvanceChatVisuals()
        {
            if (_elements.MoveNext())
            {
                _player.UpdateDialogue(_elements.Current);
                _isCharacterTalking = _elements.Current.IsCharacterTalking;
                if (_isCharacterTalking)
                    _personImage = _selectedPerson.CreateFacingImage(_elements.Current.Expression);
            }
        }

        private void EndMemory()
        {
            _isInTheMiddleOfDialog = false;
            _clickUI.Add(GameObjects.Hud.HudBranch);
            _clickUI.Add(_personMemoriesBranch);
            _clickUI.Add(_dialogMemoriesBranch);
            _clickUI.Remove(_dialogueAdvancer);
        }

        public void Draw()
        {
            if (_isInTheMiddleOfDialog)
            {
                UI.FillScreen(_locationMemory);
                if (_isCharacterTalking)
                    _personImage.Draw();
                _personName.Draw();
                _player.Draw();
                _reader.Draw();
            }
            else
            {
                _characterOptions.ForEach(c => c.Draw(Transform2.Zero));
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