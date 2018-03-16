using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Scenes;
using SpaceResortMurder.Scenes;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Credits
{
    public sealed class CreditsScene : JamScene
    {
        protected override void OnInit()
        {
            Audio.PlayMusicOnce("Credits");
            Add(UiButtons.Back(() => Scene.NavigateTo(GameResources.MainMenuSceneName)));

            var anim = new TimCredit();
            Add(anim);
            anim.Start(() => { });
        }

        protected override void DrawBackground()
        {
        }

        protected override void DrawForeground()
        {
        }
    }
}