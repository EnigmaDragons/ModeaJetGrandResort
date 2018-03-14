using System;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Render;

namespace SpaceResortMurder.State
{
    public static class CurrentOptions
    {
        private static Options _value { get; set; }
        public static bool IsFullscreen { get => _value.IsFullscreen; set => _value.IsFullscreen = value; }
        public static float Scale { get => _value.Scale; set => _value.Scale = value; }
        public static float MusicVolume { get => _value.MusicVolume; set => _value.MusicVolume = value; }
        public static float SoundVolume { get => _value.SoundVolume; set => _value.SoundVolume = value; }
        public static double MillisPerTextCharacter { get => _value.MillisPerTextCharacter; set => _value.MillisPerTextCharacter = value; }
        public static bool TutorialsAreEnabled { get => _value.TutorialsEnabled; set => _value.TutorialsEnabled = value; }

        static CurrentOptions()
        {
            Load();
        }

        public static void Reset()
        {
            _value = new Options();
            GameObjects.IO.Save("options", _value);
        }

        public static void Load()
        {
            _value = GameObjects.IO.HasSave("options")
                ? GameObjects.IO.Load<Options>("options")
                : new Options();
        }

        public static void UpdateDisplay(Action<Options> update)
        {
            Update(update);
            SetDisplay();
        }

        public static void Update(Action<Options> update)
        {
            update(_value);
            GameObjects.IO.Save("options", _value);
            Audio.SoundVolume = _value.SoundVolume;
            Audio.MusicVolume = _value.MusicVolume;
        }

        private static void SetDisplay()
        {
            var _options = _value;
            var x = new Display((int)Math.Round(_options.Scale * 1920), (int)Math.Round(_options.Scale * 1080),
                _options.IsFullscreen, _options.Scale);
            Console.WriteLine("Fullscreen: " + x.FullScreen + " Scale: " + x.Scale + "" + " Game Width: " + x.GameWidth + " Game Height: " + x.GameHeight);
            CurrentDisplay.Display = x;
        }
    }
}
