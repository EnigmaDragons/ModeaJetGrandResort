using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Common;

namespace MonoDragons.Core.Text
{
    public static class DefaultFont
    {
        public static SpriteFont Font { get; set; }

        public static string Name { get; set; } = "Fonts/Audiowide";
        public static Color Color { get; set; } = Color.White;
        public static Optional<int> FutureLineSpacing { get; set; } = new Optional<int>();
        public static Optional<float> FutureSpacing { get; set; } = new Optional<float>();

        public static void Load(ContentManager content)
        {
            Font = content?.Load<SpriteFont>(Name);
            if (FutureLineSpacing.HasValue)
                Font.LineSpacing = FutureLineSpacing.Value;
            if (FutureSpacing.HasValue)
                Font.Spacing = FutureSpacing.Value;
        }
    }
}
