using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
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
        private ImageTextButton _changeModeButton;

        protected override void OnInit()
        {
            _savingEnabled = CurrentGameState.CurrentLocation != GameResources.MainMenuSceneName;
            _headerText = UiLabels.FullWidthHeaderLabel("Game", Color.White);
            _changeModeButton = UiButtons.MenuSmallBlue("Load", new Vector2(840, 960),
                () => SetMode(_mode == SaveMode.Save ? SaveMode.Load : SaveMode.Save));
            if(_savingEnabled)
                Add(_changeModeButton);
            SetMode(_savingEnabled ? SaveMode.Save : SaveMode.Load);
            Add(UiButtons.BackBlue(() => Scene.NavigateTo(CurrentGameState.CurrentLocation)));

            var positions = new[] {new Vector2(320, 200), new Vector2(1120, 200), new Vector2(320, 600), new Vector2(1120, 600),};
            for (var i = 0; i < 4; i++)
            {
                var s = new SaveSlotView(positions[i], SaveSlot.Create(i), () => _mode);
                s.Init();
                AddUi(s);
            }
        }

        private void SetMode(SaveMode mode)
        {
            _mode = mode;
            _changeModeButton.Text = _mode == SaveMode.Save ? "Load" : "Save";
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
