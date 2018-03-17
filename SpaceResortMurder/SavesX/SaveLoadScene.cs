using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Scenes;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.SavesX
{
    public sealed class SaveLoadScene : JamScene
    {
        private bool _savingEnabled;
        private Label _headerText;
        private SaveMode _mode;

        protected override void OnInit()
        {
            _savingEnabled = CurrentGameState.CurrentLocation != GameResources.MainMenuSceneName;
            _headerText = UiLabels.HeaderLabel("Game", Color.White);
            ChangeMode(_savingEnabled ? SaveMode.Save : SaveMode.Load);
            if (_savingEnabled)
                Add(UiButtons.Menu("Save", new Vector2(380, 900), () => ChangeMode(SaveMode.Save)));
            Add(UiButtons.Menu("Load", new Vector2(780, 900), () => ChangeMode(SaveMode.Load)));
            //Add(UiButtons.Menu("Delete", new Vector2(1180, 900), () => ChangeMode(SaveMode.Delete)));
            Add(UiButtons.Back(() => Scene.NavigateTo(CurrentGameState.CurrentLocation)));

            var positions = new[] {new Vector2(320, 200), new Vector2(1120, 200), new Vector2(320, 600), new Vector2(1120, 600),};
            for (var i = 0; i < 4; i++)
            {
                var s = new SaveSlotView(positions[i], SaveSlot.Create(i), () => _mode);
                s.Init();
                AddUi(s);
            }
        }

        private void ChangeMode(SaveMode mode)
        {
            _mode = mode;
            _headerText.Text = $"{mode.ToString()} Game";
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("UI/SaveBg");
            UI.Darken();
        }

        protected override void DrawForeground()
        {
            _headerText.Draw();
        }
    }
}
