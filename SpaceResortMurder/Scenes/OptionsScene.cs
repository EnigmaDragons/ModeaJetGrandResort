using Microsoft.Xna.Framework;
using MonoDragons.Core.Scenes;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using System;

namespace SpaceResortMurder.Scenes
{
    public sealed class OptionsScene : JamScene
    {
        private const int xOff = -144;
        private const int yInc = 72;
        private int _startingY;
        private IVisual _headerText;
        private ImageLabel _soundVolume;
        private ImageLabel _musicVolume;

        protected override void OnInit()
        {
            _headerText = UiLabels.HeaderLabel("Options", Color.White);
            Add(UiButtons.Back(new Vector2(7, UI.OfScreenHeight(1.0f) - 166), () => Scene.NavigateTo(CurrentGameState.Instance.CurrentLocation)));

            _startingY = UI.OfScreenHeight(0.18f); 
            AddTextSpeedOptions();
            AddDisplayOptions();
            AddAudioOptions();
            AddResetControls();
        }

        private void AddResetControls()
        {
            var rowY = UI.OfScreenHeight(0.76f);
            Add(UiLabels.Option("Resets", new Vector2(XPos(0.5f), Height(0, rowY))));
            Add(UiButtons.Menu("Reset Options", new Vector2(XPos(0.40f), Height(1, rowY)),
                () => CurrentOptions.UpdateDisplay(x => CurrentOptions.Reset())));
            Add(UiButtons.Menu("Delete Save", new Vector2(XPos(0.60f), Height(1, rowY)), () => CurrentGameState.Reset()));
        }

        private void AddTextSpeedOptions()
        {
            var colX = XPos(0.25f);
            Add(UiLabels.Option("Text Speed", new Vector2(colX, Height(0))));
            Add(UiButtons.Menu("Slow", new Vector2(colX, Height(1)), () => CurrentOptions.Update(x => x.MillisPerTextCharacter = 45)));
            Add(UiButtons.Menu("Normal", new Vector2(colX, Height(2)), () => CurrentOptions.Update(x => x.MillisPerTextCharacter = 30)));
            Add(UiButtons.Menu("Fast", new Vector2(colX, Height(3)), () => CurrentOptions.Update(x => x.MillisPerTextCharacter = 15)));
            Add(UiButtons.Menu("Instant", new Vector2(colX, Height(4)), () => CurrentOptions.Update(x => x.MillisPerTextCharacter = 0)));
        }

        private void AddDisplayOptions()
        {
            var colX = XPos(0.50f);
            Add(UiLabels.Option("Display", new Vector2(colX, Height(0))));
            Add(UiButtons.Menu("Toggle FullScreen", new Vector2(colX, Height(1)), () => CurrentOptions.UpdateDisplay(x => x.IsFullscreen = !x.IsFullscreen)));

            Add(UiButtons.Menu("800x450", new Vector2(colX, Height(3)), () => CurrentOptions.UpdateDisplay(x => x.Scale = 0.5f)));
            Add(UiButtons.Menu("1200x675", new Vector2(colX, Height(4)), () => CurrentOptions.UpdateDisplay(x => x.Scale = 0.75f)));
            Add(UiButtons.Menu("1600x900", new Vector2(colX, Height(5)), () => CurrentOptions.UpdateDisplay(x => x.Scale = 1)));
        }

        private void AddAudioOptions()
        {
            var colX = XPos(0.75f);
            Add(UiLabels.Option("Audio", new Vector2(colX, Height(0))));
            Add(UiButtons.Menu("Sound +", new Vector2(colX, Height(1)), () =>
            {
                CurrentOptions.Update((x) => x.SoundVolume = Math.Min(x.SoundVolume + 0.1f, 1));
                _soundVolume.Text = GetSoundVolumeText();
            }));
            _soundVolume = VolumeLabel(GetSoundVolumeText(), new Vector2(colX, Height(2)), Color.Black);
            Add(_soundVolume);
            Add(UiButtons.Menu("Sound -", new Vector2(colX, Height(3)), () =>
                {
                    CurrentOptions.Update((x) => x.SoundVolume = Math.Max(x.SoundVolume - 0.1f, 0));
                    _soundVolume.Text = GetSoundVolumeText();
                }));
            Add(UiButtons.Menu("Music +", new Vector2(colX, Height(4)), () =>
            {
                CurrentOptions.Update((x) => x.MusicVolume = Math.Min(x.MusicVolume + 0.1f, 1));
                _musicVolume.Text = GetMusicVolumeText();
            }));
            _musicVolume = VolumeLabel(GetMusicVolumeText(), new Vector2(colX, Height(5)), Color.Black);
            Add(_musicVolume);
            Add(UiButtons.Menu("Music -", new Vector2(colX, Height(6)), () =>
                {
                    CurrentOptions.Update((x) => x.MusicVolume = Math.Max(x.MusicVolume - 0.1f, 0));
                    _musicVolume.Text = GetMusicVolumeText();
                }));
        }

        private static string GetMusicVolumeText()
        {
            return $"Music: {(int)Math.Round(CurrentOptions.MusicVolume * 10)}";
        }

        private static string GetSoundVolumeText()
        {
            return $"Sound: {(int)Math.Round(CurrentOptions.SoundVolume * 10)}";
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("UI/OptionsBg");
            UI.Darken();
        }

        protected override void DrawForeground()
        {
            UI.FillScreen("UI/ScreenOverlay");
            _headerText.Draw();
        }

        private int Height(int index)
        {
            return Height(index, _startingY);
        }

        private int Height(int index, int startingY)
        {
            var extra = index > 0 ? yInc / 2 : 0;
            return startingY + extra + (index * yInc);
        }

        private int XPos(float factorOfScreen)
        {
            return UI.OfScreenWidth(factorOfScreen) + xOff;
        }
        
        public static ImageLabel VolumeLabel(string text, Vector2 position, Color color)
        {
            return new ImageLabel(new Transform2(position, new Size2(288, 60)), "UI/PixelButton")
            {
                TextColor = color,
                Text = text
            };
        }
    }
}