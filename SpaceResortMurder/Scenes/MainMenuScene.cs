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
            Audio.PlayMusic("MainTheme");
            Add(UiButtons.Menu("Start Game", new Vector2(144, 576), () => Scene.NavigateTo(nameof(PoliceCruiserInterior))));
            if (GameObjects.IO.HasSave("save"))
                Add(UiButtons.Menu("Continue Game", new Vector2(144, 672), () =>
                {
                    CurrentGameState.Load();
                    Scene.NavigateTo(CurrentGameState.Instance.CurrentLocation);
                }));
            Add(UiButtons.Menu("Credits", new Vector2(144, 864), () => Scene.NavigateTo(GameResources.CreditsSceneName)));
            Add(UiButtons.Menu("Options", new Vector2(144, 768), () =>
            {
                CurrentGameState.Instance.CurrentLocation = "Main Menu";
                Scene.NavigateTo(GameResources.OptionsSceneName);
            }));
            Add(UiButtons.Menu("Exit Game", new Vector2(144, 960), () => CurrentGame.TheGame.Exit()));
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("UI/MainMenuBg");
            UI.Darken();
            World.Draw("characters/resort_manager_colored", new Rectangle(840, 600, 479, 1124));
            UI.DrawCenteredWithOffset("UI/Title", new Vector2(0, -180));
            UI.DrawCenteredWithOffset("UI/Copyright", new Vector2(313, 32), new Vector2(744, 494));
        }

        protected override void DrawForeground()
        {
            UI.FillScreen("UI/MainMenuBorder");
        }
    }
}