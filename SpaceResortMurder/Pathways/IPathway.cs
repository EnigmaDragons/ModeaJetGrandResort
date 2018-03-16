using System;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Pathways
{
    public interface IPathway
    {
        bool IsTraversible { get; }
        VisualClickableUIElement CreateButton(Action<string> showNonTraversibleDialogue);
    }
}
