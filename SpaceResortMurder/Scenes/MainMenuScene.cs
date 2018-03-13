using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Scenes
{
    public sealed class MainMenuScene : JamScene
    {
        protected override void OnInit()
        {
            GameState.Instance = new GameState();
            Audio.PlayMusic("MainTheme");

            Add(UiButtons.Menu("Start Game", new Vector2(120, 480), () => Scene.NavigateTo(nameof(DockingBay))));
            if (GameObjects.IO.HasSave("save"))
                Add(UiButtons.Menu("Continue Game", new Vector2(120, 560), () =>
                {
                    GameState.Instance = GameObjects.IO.Load<GameState>("save");
                    Scene.NavigateTo(GameState.Instance.CurrentLocation);
                }));
            Add(UiButtons.Menu("Credits", new Vector2(120, 720), () => Scene.NavigateTo(GameResources.CreditsSceneName)));
            Add(UiButtons.Menu("Options", new Vector2(120, 640), () =>
            {
                GameState.Instance.CurrentLocation = "Main Menu";
                Scene.NavigateTo(GameResources.OptionsSceneName);
            }));
            Add(UiButtons.Menu("Exit Game", new Vector2(120, 800), () => GameInstance.TheGame.Exit()));
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("UI/MainMenuBg");
            UI.Darken();
            World.Draw("characters/resort_manager_colored", new Vector2(700, 500));
            UI.DrawCenteredWithOffset("UI/Title", new Vector2(0, -150));
            UI.DrawCenteredWithOffset("UI/Copyright", new Vector2(261, 27), new Vector2(620, 412));
        }

        protected override void DrawForeground()
        {
            UI.FillScreen("UI/MainMenuBorder");
        }
    }
}