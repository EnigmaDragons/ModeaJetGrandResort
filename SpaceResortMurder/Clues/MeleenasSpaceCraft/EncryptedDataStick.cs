using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.State;
using SpaceResortMurder.Dialogues.Meleena;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class EncryptedDataStick : Clue
    {
        public EncryptedDataStick() : base(
            "Clues/DataEncrypted-Small", 
            new Transform2(new Vector2(1000, 880), new Size2(216, 180)), 
            new Size2(396, 330), 
            nameof(EncryptedDataStick),
            "")
        {
            IsActive = () => !(CurrentGameState.IsThinking(nameof(CareToShowTheDirtYouCollected))
                || CurrentGameState.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime))
                || CurrentGameState.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive)));
            IsVisible = IsActive;
        }
    }
}
