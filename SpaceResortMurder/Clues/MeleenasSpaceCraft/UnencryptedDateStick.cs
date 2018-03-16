using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.State;
using SpaceResortMurder.Dialogues.Meleena;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class UnencryptedDataDrive : Clue
    {
        public UnencryptedDataDrive() : base(
            "Clues/DataDecrypted-Small",
            new Transform2(new Vector2(1000, 880), new Size2(216, 180)),
            new Size2(396, 330),
            nameof(UnencryptedDataDrive))
        {
            IsActive = () => CurrentGameState.IsThinking(nameof(DeckersMakeTheWorldWorse))
                || CurrentGameState.IsThinking(nameof(IWontReportDataRaven));
            IsVisible = IsActive;
        }
    }
}