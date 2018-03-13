using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;
using System.Linq;

namespace SpaceResortMurder.LocationsX
{
    public abstract class Location
    {
        private readonly TextButton _button;
        private readonly IVisual _newIndicator;
        private readonly string _location;
        public VisualClickableUIElement Button => _button;
        public IVisual NewIndicator => _newIndicator;
        public bool IsNewOrHasNewDialogs => !CurrentGameState.Instance.HasViewedItem(_location)
            || GameObjects.Characters.GetPeopleAt(_location).Any(p => p.GetNewDialogs().Count != 0);

        protected Location(string location, string name, Vector2 position)
        {
            _location = location;
            _button = new TextButton(new Rectangle((int)position.X, (int)position.Y, 150, 150), () => Scene.NavigateTo(location), name, 
                Color.FromNonPremultiplied(100, 0, 200, 100), Color.FromNonPremultiplied(150, 0, 200, 100), Color.FromNonPremultiplied(200, 0, 200, 100));
            _newIndicator = new ImageBox
            {
                Transform = new Transform2(new Vector2(position.X + 114, position.Y), new Size2(36, 36)),
                Image = "UI/NewRedIconBorderless"
            };
        }

        public abstract bool IsAvailable();
    }
}
