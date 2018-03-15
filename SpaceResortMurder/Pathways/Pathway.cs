using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Pathways
{
    public abstract class Pathway
    {
        private readonly string _image;
        private readonly Transform2 _placement;
        private readonly string _location;
        private readonly string _pathway;

        protected Pathway(string pathway, string image, Transform2 placement, string location)
        {
            _image = image;
            _placement = placement;
            _location = location;
            _pathway = pathway;
        }

        public abstract bool IsTraversible();

        public VisualClickableUIElement CreateButton(Action<string> showNonTraversibleDialogue)
        {
            return new ExpandingImageButton(_image, _image, _image, _placement, _placement.Size * 0.2f,
                () =>
                {
                    if (IsTraversible())
                        Scene.NavigateTo(_location);
                    else
                        showNonTraversibleDialogue(_pathway);
                });
        }
    }
}
