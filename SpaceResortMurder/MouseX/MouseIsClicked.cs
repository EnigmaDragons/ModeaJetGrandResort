using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Engine;

namespace SpaceResortMurder.MouseX
{
    public class MouseIsClicked
    {
        private MouseState _prevState;

        public bool Evaluate()
        {
            var x = MouseIsOnScreen() && Mouse.GetState().LeftButton == ButtonState.Released && _prevState.LeftButton == ButtonState.Pressed;
            _prevState = Mouse.GetState();
            return x;
        }

        private static bool MouseIsOnScreen()
        {
            var mousePos = Mouse.GetState().Position;
            return mousePos.X >= 0 && mousePos.X <= CurrentGame.GraphicsDevice.Viewport.Width
                   && mousePos.Y >= 0 && mousePos.Y <= CurrentGame.GraphicsDevice.Viewport.Height;
        }
    }
}
