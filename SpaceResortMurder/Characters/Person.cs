using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Dialogs;

namespace SpaceResortMurder.Characters
{
    public abstract class Person
    {
        private readonly ImageBox _facingImage;
        private readonly List<Dialog> _dialogs;

        public string Image { get; }

        protected Person(string image, Size2 size, params Dialog[] dialogs)
        {
            Image = image;
            _dialogs = dialogs.ToList();
            _facingImage = new ImageBox(new Transform2(new Vector2((1600 - size.Width) / 2, 900 - size.Height), size), image);
        }

        public IReadOnlyList<Dialog> GetDialogs()
        {
            return _dialogs.Where(x => x.IsActive()).OrderBy(x => x.IsExplored).ToList();
        }

        public void DrawTalking()
        {
            _facingImage.Draw(Transform2.Zero);
        }

        public abstract string WhereAreYou();
        public abstract Transform2 WhereAreYouStanding();
    }
}
