using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResortMurder.Scenes
{
    public class SaveLoadScene : JamScene
    {
        private enum Mode
        {
            Save,
            Load,
            Delete
        }

        private bool _savingEnabled;
        private Mode _mode;
        private ImageTextButton[] _saveSlotButtons = new ImageTextButton[4];
        private bool[] _isSaveSlotUsed = new bool[4];

        protected override void OnInit()
        {
            _savingEnabled = CurrentGameState.CurrentLocation != GameResources.MainMenuSceneName;
            for(var i = 0; i < 4; i++)
            {
                var savedI = i;
                _isSaveSlotUsed[i] = GameObjects.IO.HasSave("Save " + i);
                _saveSlotButtons[i] = UiButtons.Menu("", new Vector2(Width(i), 400), () => SelectSaveSlot(savedI),
                    () => _mode == Mode.Save || _isSaveSlotUsed[savedI]);
                if (_isSaveSlotUsed[i])
                {
                    var save = GameObjects.IO.Load<GameState>("Save " + i);
                    Add(new ImageBox() { Transform = new Transform2(new Vector2(Width(i) + 20, 510), new Size2(320, 180)),
                        Image = save.CurrentLocationImage });
                    Add(new Label() { Transform = new Transform2(new Vector2(Width(i)+ 20, 475), new Size2(320, 35)), Text = save.PlayerName,
                        BackgroundColor = new Color(134, 56, 134) });
                }
            }
            ChangeMode(_savingEnabled ? Mode.Save: Mode.Load);
            if (_savingEnabled)
                Add(UiButtons.Menu("Save", new Vector2(380, 100), () => ChangeMode(Mode.Save)));
            Add(UiButtons.Menu("Load", new Vector2(780, 100), () => ChangeMode(Mode.Load)));
            Add(UiButtons.Menu("Delete", new Vector2(1180, 100), () => ChangeMode(Mode.Delete)));
            Add(UiButtons.Back(() => Scene.NavigateTo(CurrentGameState.CurrentLocation)));
            _saveSlotButtons.ForEach(b => Add(b));
        }

        private int Width(int column)
        {
            return 90 + 460 * column;
        }

        private void SelectSaveSlot(int slot)
        {
            if (_mode == Mode.Save)
                Save(slot);
            else if (_mode == Mode.Load)
                Load(slot);
            else
                Delete(slot);
            Scene.NavigateTo(GameResources.LoadingSceneName);
        }

        private void Save(int slot)
        {
            GameObjects.IO.Save("Save " + slot, CurrentGameState.Value);
        }

        private void Load(int slot)
        {
            CurrentGameState.Load("Save " + slot);
        }

        private void Delete(int slot)
        {
            GameObjects.IO.Delete("Save " + slot);
        }

        private void ChangeMode(Mode mode)
        {
            _mode = mode;
            var modeText = mode.ToString();
            for(var i = 0; i < 4; i++)
            {
                _saveSlotButtons[i].Text = modeText + " Slot " + i;
                _saveSlotButtons[i].IsEnabled = _mode == Mode.Save || _isSaveSlotUsed[i];
            }
        }

        protected override void DrawBackground()
        {
        }

        protected override void DrawForeground()
        {
        }
    }
}
