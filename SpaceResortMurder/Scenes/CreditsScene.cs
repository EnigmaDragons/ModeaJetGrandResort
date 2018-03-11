using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Scenes;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Scenes
{
    public sealed class CreditsScene : JamScene
    {
        protected override void OnInit()
        {
            Audio.PlayMusicOnce("Credits");
            Add(UiButtons.Menu("Main Menu", new Vector2(700, 800), () => Scene.NavigateTo(GameResources.MainMenuSceneName)));
        }

        protected override void DrawBackground()
        {
        }

        protected override void DrawForeground()
        {
        }
    }
}