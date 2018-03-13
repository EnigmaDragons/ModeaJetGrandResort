using System;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Render;

namespace SpaceResortMurder.State
{
    public static class CurrentOptions
    {
        public static Options Instance { get; private set; }

        static CurrentOptions()
        {
            Load();
        }

        public static void Reset()
        {
            Instance = new Options();
        }

        public static void Load()
        {
            Instance = GameObjects.IO.HasSave("options")
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
            update(Instance);
            GameObjects.IO.Save("options", Instance);
            Audio.SoundVolume = Instance.SoundVolume;
            Audio.MusicVolume = Instance.MusicVolume;
        }

        private static void SetDisplay()
        {
            var _options = Instance;
            var x = new Display((int)Math.Round(_options.Scale * 1600), (int)Math.Round(_options.Scale * 900),
                _options.IsFullscreen, _options.Scale);
            Console.WriteLine("Fullscreen: " + x.FullScreen + " Scale: " + x.Scale + "" + " Game Width: " + x.GameWidth + " Game Height: " + x.GameHeight);
            CurrentDisplay.Display = x;
        }
    }
}
