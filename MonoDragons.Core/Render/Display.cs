using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;

namespace MonoDragons.Core.Render
{
    public class Display
    {
        public readonly int ProgramWidth;
        public readonly int ProgramHeight;
        public readonly int GameWidth;
        public readonly int GameHeight;
        public readonly bool FullScreen;
        public readonly float Scale;

        public Display(int width, int height, bool fullScreen, float scale = 1)
        {
            FullScreen = fullScreen;
            if (FullScreen)
            {
                var widthScale = (float)GameInstance.TheGame.GraphicsDevice.DisplayMode.Width / width;
                var heightScale = (float)GameInstance.TheGame.GraphicsDevice.DisplayMode.Height / height;
                Scale = scale * Math.Min(heightScale, widthScale);
                GameWidth = (int)Math.Round(width * Scale);
                GameHeight = (int)Math.Round(height * Scale);
                ProgramWidth = GameInstance.TheGame.GraphicsDevice.DisplayMode.Width;
                ProgramHeight = GameInstance.TheGame.GraphicsDevice.DisplayMode.Height;
            }
            else
            {
                Scale = scale;
                GameWidth = width;
                GameHeight = height;
                ProgramWidth = GameWidth;
                ProgramHeight = GameHeight;
            }
        }

        public void Apply(GraphicsDeviceManager device)
        {
            device.PreferredBackBufferWidth = ProgramWidth;
            device.PreferredBackBufferHeight = ProgramHeight;
            device.IsFullScreen = FullScreen;
            device.ApplyChanges();
        }
    }
}
