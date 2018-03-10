using Microsoft.Xna.Framework;

namespace MonoDragons.Core.Render
{
    public static class CurrentDisplay
    {
        private static Display _display;

        internal static void Init(Display display)
        {
            _display = display;
        }

        public static Display Get()
        {
            return _display;
        }

        public static Rectangle FullScreenRectangle => new Rectangle(0, 0, _display.ProgramWidth, _display.ProgramHeight);
        public static Vector2 Size => new Vector2(_display.ProgramWidth, _display.ProgramHeight);
    }
}
