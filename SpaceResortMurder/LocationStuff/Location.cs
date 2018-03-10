using Microsoft.Xna.Framework;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.LocationStuff
{
    public abstract class Location
    {
        private readonly TextButton _button;
        public VisualClickableUIElement Button => _button;

        protected Location(string location, string name, Vector2 position)
        {
            _button = new TextButton(new Rectangle((int)position.X, (int)position.Y, 150, 150), () => Scene.NavigateTo(location), name, 
                Color.FromNonPremultiplied(100, 0, 200, 100), Color.FromNonPremultiplied(150, 0, 200, 100), Color.FromNonPremultiplied(200, 0, 200, 100));
        }

        public abstract bool IsAvailable();
    }
}
