using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Pathways
{
    public abstract class LightUpPathway : IPathway
    {
        private readonly Transform2 _transform;
        private readonly string _destination;
        private readonly string _image;
        private readonly string _toolTipText;

        protected LightUpPathway(Transform2 transform, string destination, string image, string toolTipText)
        {
            _transform = transform;
            _destination = destination;
            _image = image;
            _toolTipText = toolTipText;
        }

        public abstract bool IsTraversible { get; }

        public VisualClickableUIElement CreateButton(Action<string> showNonTraversibleDialogue)
        {
            return new ImageButton("Images/None", _image, _image, _transform, () =>
                {
                    if (IsTraversible)
                        Scene.NavigateTo(_destination);
                    else
                        showNonTraversibleDialogue(GameResources.GetPathwayText(GetType().Name));
                })
                { TooltipText = _toolTipText };
        }
    }
}
