using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.Clues
{
    public abstract class Clue
    {
        private readonly string _image;
        private readonly Action _onInvestigate;
        private readonly Transform2 _position;

        public List<string> InvestigationLines { get; }
        public ImageBox FacingImage { get; }

        protected Clue(string image, Transform2 position, Size2 zoomInSize, Action onInvestigate, params string[] investigationLines)
        {
            _image = image;
            _onInvestigate = onInvestigate;
            InvestigationLines = investigationLines.ToList();
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
                _onInvestigate();
                onClick();
            });
        }
    }
}
