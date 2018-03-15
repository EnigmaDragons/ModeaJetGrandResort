using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;
using System;

namespace SpaceResortMurder.Clues
{
    public abstract class Clue : IVisual
    {
        private readonly string _clueId;
        private readonly string _roomImage;
        private readonly string _closeUpImage;
        private readonly Transform2 _position;
        private readonly Size2 _zoomInSize;

        public string[] InvestigationLines { get; }
        public ImageBox FacingImage { get; }
        public Func<bool> IsActive { get; protected set; }
        protected Func<bool> IsVisible { private get; set; }

        protected Clue(string roomImage, Transform2 position, Size2 zoomInSize, string clueId)
            : this(roomImage, roomImage, position, zoomInSize, clueId) { }

        protected Clue(string roomImage, string closeUpImage, Transform2 position, Size2 zoomInSize, string clueId)
        {
            IsActive = () => true;
            IsVisible = () => true;
            _roomImage = roomImage;
            _closeUpImage = closeUpImage;
            _clueId = clueId;
            InvestigationLines = GameResources.GetClueLines(clueId);
            _position = position;
            _zoomInSize = zoomInSize;
            FacingImage = new ImageBox
            {
                Transform = new Transform2(new Vector2((1920 - zoomInSize.Width) / 2, 500 - zoomInSize.Height), zoomInSize),
                Image = roomImage
            };
        }

        public VisualClickableUIElement CreateButton(Action onClick)
        {
            return new ExpandingImageButton(_roomImage, _roomImage, _roomImage, _position, _position.Size / 6, () =>
            {
                if (!CurrentGameState.IsThinking(_clueId))
                    Event.Publish(new ThoughtGained(_clueId));
                onClick();
            }, IsVisible)
            { HoveredCursor = Cursors.Interactive };
        }

        public void Draw(Transform2 parentTransform)
        {
            var off = new Vector2(0, UI.OfScreenHeight(-0.16f));
            UI.DrawCenteredWithOffset("UI/ClueBox", new Vector2(646, 364), off);
            UI.DrawCenteredWithOffset(_closeUpImage, _zoomInSize.ToVector(), off);
        }
    }
}
