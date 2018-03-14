﻿using SpaceResortMurder.Clues.MeleenasSpaceCraft;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Dialogues.Meleena
{
    public class CareToShowTheDirtYouCollected : Dialogue
    {
        public CareToShowTheDirtYouCollected() : base(nameof(CareToShowTheDirtYouCollected)) {}

        public override bool IsActive()
        {
            return CurrentGameState.Instance.IsThinking(nameof(DataStick))
                   && CurrentGameState.Instance.IsThinking(nameof(ImOnlyInvestigatingTheMurder));
        }
    }
}