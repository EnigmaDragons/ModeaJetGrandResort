using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.UserInterface
{
    public sealed class ImageBox : IVisual
    {
        public Transform2 Transform { get; set; }
        public string Image { get; set; } = "none";
        
        public void Clear()
        {
            Image = "none";
        }

        public void Draw(Transform2 parentTransform)
        {
            if (!"none".Equals(Image))
                World.Draw(Image, parentTransform + Transform);
        }
    }
}
