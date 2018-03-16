using SpaceResortMurder.Dialogues.Warren;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder.ObjectivesX
{
    public class GoFindOutTheManagersAccount : Objective
    {
        public GoFindOutTheManagersAccount() : base(nameof(GoFindOutTheManagersAccount)) {}

        public override bool IsActive()
        {
            return CurrentGameState.IsThinking(nameof(NeedASearchOrder)) && !CurrentGameState.IsThinking(nameof(ZaidsAccount));
        }
    }
}
