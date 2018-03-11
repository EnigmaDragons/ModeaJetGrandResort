using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.EventSystem;

namespace SpaceResortMurder.Clues
{
    public abstract class Clue
    {
        private readonly string _image;
        private readonly string _clue;
        private readonly Transform2 _position;

        public string[] InvestigationLines { get; }
        public ImageBox FacingImage { get; }

        protected Clue(string image, Transform2 position, Size2 zoomInSize, string clue)
        {
            _image = image;
            _clue = clue;
            InvestigationLines = GameResources.GetDialogOrClueLines(clue);
            _position = position;
            FacingImage = new ImageBox
            {
                Transform = new Transform2(new Vector2((1600 - zoomInSize.Width) / 2, 500 - zoomInSize.Height), zoomInSize),
                Image = image
            };
        }

        public ImageButton CreateButton(Action onClick)
        {
            return new ImageButton(_image, _image, _image, _position, () => 
            {
                if(!GameState.Instance.IsThinking(_clue))
                    Event.Publish(new ThoughtGained(_clue));
                onClick();
            });
        }
    }
}
