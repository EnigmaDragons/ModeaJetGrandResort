using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.UserInterface
{
    public sealed class ImageLabel : IVisual, IDisposable
    {
        private readonly Label _label;
        private readonly string _imageName;

        private Transform2 _transform = new Transform2(new Size2(300, 60));

        public string Font { set => _label.Font = value; }
        public string Text { set => _label.Text = value; }
        public Color TextColor { set => _label.TextColor = value; }

        public Transform2 Transform
        {
            get => _transform;
            set { _transform = value; UpdateLabelTransform(); }
        }

        public ImageLabel(Transform2 transform, string imageName)
        {
            _transform = transform;
            _imageName = imageName;
            _label = new Label { BackgroundColor = Color.Transparent };
        }

        public void Draw(Transform2 parentTransform)
        {
            World.Draw(_imageName, parentTransform + _label.Transform);
            _label.Draw(parentTransform);
        }

        private void UpdateLabelTransform()
        {
            _label.Transform = _transform + new Transform2(new Vector2(10, 0), new Size2(-20, 0));
        }

        public void Dispose()
        {
            _label.Dispose();
        }
    }
}
