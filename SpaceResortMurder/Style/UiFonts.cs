using MonoDragons.Core.Text;

namespace SpaceResortMurder.Style
{
    public static class UiFonts
    {
        public static string Body => "Fonts/BodyFont";
        public static string Header => "Fonts/HeaderFont";

        public static void Init()
        {
            DefaultFont.Name = Body;
            DefaultFont.Color = UiStyle.TextBlack;
        }
    }
}
