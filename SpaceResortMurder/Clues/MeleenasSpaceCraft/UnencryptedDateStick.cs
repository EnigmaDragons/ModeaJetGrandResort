using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.State;
using SpaceResortMurder.Dialogues.Meleena;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class UnencryptedDataStick : Clue
    {
        public UnencryptedDataStick() : base(
            "Placeholder/datastick",
            new Transform2(new Vector2(800, 800), new Size2(100, 50)),
            new Size2(400, 200),
            nameof(UnencryptedDataStick))
        {
            IsActive = () => CurrentGameState.Instance.IsThinking(nameof(CareToShowTheDirtYouCollected))
                || CurrentGameState.Instance.IsThinking(nameof(ObstructionOfJusticeWillAddToYourPrisonTime))
                || CurrentGameState.Instance.IsThinking(nameof(WontTurnYouInIfYouUnencryptThisDrive));
            IsVisible = IsActive;
        }
    }
}