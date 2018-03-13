using Microsoft.Xna.Framework;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ResolutionsX
{
    public abstract class Resolution
    {
        private readonly string _resolution;

        public Resolution(string resolution)
        {
            _resolution = resolution;
        }

        public abstract bool IsActive();

        public VisualClickableUIElement CreateButton(Vector2 position)
        {
            return new ImageTextButton(new Rectangle((int)position.X, (int)position.Y, 360, 120), () =>
            {
                Event.Publish(new ThoughtGained(_resolution));
            }, GameResources.GetResolutionText(_resolution), "UI/DilemmaCard", "UI/DilemmaCard-Hover", "UI/DilemmaCard-Press");
        }
    }
}