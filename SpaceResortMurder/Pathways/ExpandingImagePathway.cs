using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Pathways
{
    public abstract class ExpandingImagePathway : IPathway
    {
        private readonly string _image;
        private readonly Transform2 _transform;
        private readonly string _location;
        private readonly string _pathway;
        private readonly string _tooltip;

        protected ExpandingImagePathway(string pathway, string image, Transform2 transform, string location, string tooltip)
        {
            _tooltip = tooltip;
            _image = image;
            _transform = transform;
            _location = location;
            _pathway = pathway;
        }

        public abstract bool IsTraversible { get; }

        public VisualClickableUIElement CreateButton(Action<string> showNonTraversibleDialogue)
        {
            return new ExpandingImageButton(_image, _image, _image, _transform, _transform.Size * 0.2f,
                () =>
                {
                    if (IsTraversible)
                        Scene.NavigateTo(_location);
                    else
                        showNonTraversibleDialogue(GameResources.GetPathwayText(_pathway));
                }) { TooltipText = _tooltip };
        }
    }
}
