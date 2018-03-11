using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoDragons.Core.Text
{
    public static class DefaultFont
    {
        public static SpriteFont Font { get; set; }

        public static string Name { get; set; } = "Fonts/Audiowide";
        public static Color Color { get; set; } = Color.White;

        public static void Load(ContentManager content)
        {
            Font = content?.Load<SpriteFont>(Name);
        }
    }
}
