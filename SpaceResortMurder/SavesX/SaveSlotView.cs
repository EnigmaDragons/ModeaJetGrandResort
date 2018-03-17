using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.SavesX
{
    public sealed class SaveSlotView : IJamView
    {
        private readonly Vector2 _position;
        private readonly SaveSlot _slot;
        private readonly Func<SaveMode> _getMode;

        private readonly List<IVisual> _visuals = new List<IVisual>();

        public ClickUIBranch ClickUiBranch { get; } = new ClickUIBranch("Save Slots", 5);

        public SaveSlotView(Vector2 position, SaveSlot slot, Func<SaveMode> getMode)
        {
            _position = position;
            _slot = slot;
            _getMode = getMode;
        }

        public void Init()
        {
            _visuals.Add(new ImageBox { Image = "UI/SaveSlotBox", Transform = new Transform2(_position - new Vector2(5, 5), new Size2(490, 325)) });
            var button = new ExpandingImageButton(_slot.CoverImage, _slot.CoverImage, _slot.CoverImage,
                new Transform2(_position, new Size2(480, 270)), new Size2(6, 6), () => _slot.Execute(_getMode()),
                () => _slot.HasSave || _getMode() == SaveMode.Save);
            ClickUiBranch.Add(button);
            _visuals.Add(button);
            _visuals.Add(new Label { Text = _slot.PlayerName, Transform = new Transform2(_position + new Vector2(0, 270), new Size2(480, 50)) });

        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Transform2 parentTransform)
        {
            _visuals.ForEach(x => x.Draw(parentTransform));
        }
    }
}
