using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.State;
using SpaceResortMurder.Dialogues.Meleena;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class DataStick : Clue
    {
        public DataStick() : base(
            "Clues/DataStick", 
            new Transform2(new Vector2(1180, 850), new Size2(138, 86)), 
            new Size2(528, 330), 
            nameof(DataStick))
        {
            IsActive = () => !(CurrentGameState.IsThinking(nameof(CareToShowTheDirtYouCollected))
                || CurrentGameState.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime))
                || CurrentGameState.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive)));
            IsVisible = IsActive;
        }
    }
}
