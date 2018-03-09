using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Pondering
{
    public interface IDilemma
    {
        ClickableUIElement Button { get; }
        void Draw();
    }
}
