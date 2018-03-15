using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Style
{
    public interface IJamView : IVisualAutomaton
    {
        ClickUIBranch ClickUiBranch {get;}
        void Init();
    }
}
