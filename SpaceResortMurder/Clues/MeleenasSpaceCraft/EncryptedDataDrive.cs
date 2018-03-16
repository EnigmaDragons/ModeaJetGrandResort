using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.State;
using SpaceResortMurder.Dialogues.Meleena;

namespace SpaceResortMurder.Clues.MeleenasSpaceCraft
{
    public class EncryptedDataDrive : Clue
    {
        public EncryptedDataDrive() : base(
            "Clues/DataEncrypted-Small", 
            new Transform2(new Vector2(1000, 880), new Size2(216, 180)), 
            new Size2(396, 330), 
            nameof(EncryptedDataDrive),
            "Locked Data Drive")
        {
            IsActive = () => !(CurrentGameState.IsThinking(nameof(DeckersMakeTheWorldWorse))
                || CurrentGameState.IsThinking(nameof(IWontReportDataRaven)));
            IsVisible = IsActive;
        }
    }
}
