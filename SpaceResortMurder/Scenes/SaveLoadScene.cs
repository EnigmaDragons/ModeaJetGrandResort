using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
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
        private ImageTextButton[] _saveSlotButtons;
        private bool[] _isSaveSlotUsed;

        protected override void OnInit()
        {
            _savingEnabled = CurrentGameState.CurrentLocation != GameResources.MainMenuSceneName;
            _isSaveSlotUsed = new bool[]
            {
                GameObjects.IO.HasSave("Save 0"),
                GameObjects.IO.HasSave("Save 1"),
                GameObjects.IO.HasSave("Save 2"),
                GameObjects.IO.HasSave("Save 3")
            };
            _saveSlotButtons = new ImageTextButton[]
            {
                UiButtons.Menu("", new Vector2(960 - 720 - 150, 400), () => SelectSaveSlot(0), () => _mode == Mode.Save || _isSaveSlotUsed[0]),
                UiButtons.Menu("", new Vector2(960 - 360 - 50, 400), () => SelectSaveSlot(1), () => _mode == Mode.Save || _isSaveSlotUsed[1]),
                UiButtons.Menu("", new Vector2(960 + 50, 400), () => SelectSaveSlot(2), () => _mode == Mode.Save || _isSaveSlotUsed[2]),
                UiButtons.Menu("", new Vector2(960 + 360 + 150, 400), () => SelectSaveSlot(3), () => _mode == Mode.Save || _isSaveSlotUsed[3])
            };
            ChangeMode(_savingEnabled ? Mode.Save: Mode.Load);
            if (_savingEnabled)
                Add(UiButtons.Menu("Save", new Vector2(380, 100), () => ChangeMode(Mode.Save)));
            Add(UiButtons.Menu("Load", new Vector2(780, 100), () => ChangeMode(Mode.Load)));
            Add(UiButtons.Menu("Delete", new Vector2(1180, 100), () => ChangeMode(Mode.Delete)));
            Add(UiButtons.Back(() => Scene.NavigateTo(CurrentGameState.CurrentLocation)));
            _saveSlotButtons.ForEach(b => Add(b));
        }

        private void SelectSaveSlot(int slot)
        {
            if (_mode == Mode.Save)
                Save(slot);
            else if (_mode == Mode.Load)
                Load(slot);
            else
                Delete(slot);
            Scene.NavigateTo(CurrentGameState.CurrentLocation);
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
