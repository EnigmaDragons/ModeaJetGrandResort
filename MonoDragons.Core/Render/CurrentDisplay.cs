using Microsoft.Xna.Framework;

namespace MonoDragons.Core.Render
{
    public static class CurrentDisplay
    {
        private static GraphicsDeviceManager _graphics;
        private static Display _display;
        public static Display Display {
            internal get => _display;
            set
            {
                _display = value;
                _display.Apply(_graphics);
            }
        }

        internal static void Init(GraphicsDeviceManager graphics, Display display)
        {
            _graphics = graphics;
            Display = display;
        }

        public static Rectangle FullScreenRectangle => new Rectangle(0, 0, Display.GameWidth, Display.GameHeight);
    }
}
