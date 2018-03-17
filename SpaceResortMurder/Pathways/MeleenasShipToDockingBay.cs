using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Pathways
{
    public class MeleenasShipToDockingBay : IPathway
    {
        private readonly Transform2 _transform;
        private readonly string _destination;

        public MeleenasShipToDockingBay(Transform2 transform)
        {
            _transform = transform;
            _destination = nameof(DockingBay);
        }

        public bool IsTraversible => true;

        public VisualClickableUIElement CreateButton(Action<string> showNonTraversibleDialogue)
        {
            return new ImageButton("Traverse/TraverseArrowR", "Traverse/TraverseArrowR-Hover", "Traverse/TraverseArrowR-Press", _transform, () =>
            {
                if (IsTraversible)
                    Scene.NavigateTo(_destination);
                else
                    showNonTraversibleDialogue(GameResources.GetPathwayText(GetType().Name));
            }) { TooltipText = "To Docking Bay" };
        }
    }
}
