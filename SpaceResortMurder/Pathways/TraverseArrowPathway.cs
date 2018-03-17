using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Pathways
{
    public abstract class TraverseArrowPathway : IPathway
    {
        private readonly Transform2 _transform;
        private readonly string _destination;
        private readonly string _tooltip;
        private readonly string _traverseArrowType;

        protected TraverseArrowPathway(Transform2 transform, string destination, string tooltip, string traverseArrowType)
        {
            _transform = transform;
            _destination = destination;
            _tooltip = tooltip;
            _traverseArrowType = traverseArrowType;
        }

        public abstract bool IsTraversible { get; }

        public VisualClickableUIElement CreateButton(Action<string> showNonTraversibleDialogue)
        {
            return new ImageButton($"Traverse/TraverseArrow{_traverseArrowType}", 
                $"Traverse/TraverseArrow{_traverseArrowType}-Hover", 
                $"Traverse/TraverseArrow{_traverseArrowType}-Press", _transform, () =>
                {
                    if (IsTraversible)
                        Scene.NavigateTo(_destination);
                    else
                        showNonTraversibleDialogue(GameResources.GetPathwayText(GetType().Name));
                })
                { TooltipText = _tooltip };
        }
    }
}
