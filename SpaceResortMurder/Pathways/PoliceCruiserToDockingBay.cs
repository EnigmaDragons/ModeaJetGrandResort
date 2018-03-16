using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.LocationsX;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Pathways
{
    public sealed class PoliceCruiserToDockingBay : IPathway
    {
        private readonly Transform2 _transform;
        private readonly string _destination;

        public PoliceCruiserToDockingBay(Transform2 transform)
        {
            _transform = transform;
            _destination = nameof(DockingBay);
        }

        public bool IsTraversible => CurrentGameState.IsThinking(nameof(BetweenSevenAMToEightPM));

        public VisualClickableUIElement CreateButton(Action<string> showNonTraversibleDialogue)
        {
            return new ImageButton("Images/None", "Traverse/PoliceCruiserDoor", "Traverse/PoliceCruiserDoor", _transform, () =>
            {
                if (IsTraversible)
                    Scene.NavigateTo(_destination);
                else
                    showNonTraversibleDialogue(GameResources.GetPathwayText(GetType().Name));
            }) { TooltipText = "To Docking Bay" };
        }
    }
}
