using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Dialogs;
using System;

namespace SpaceResortMurder.Characters
{
    public abstract class Person
    {
        private readonly ImageBox _facingImage;
        private readonly List<Dialog> _dialogs;
        private readonly ImageBox _newDialogIcon;

        public string Image { get; }

        protected Person(string image, Size2 size, params Dialog[] dialogs)
        {
            Image = image;
            _dialogs = dialogs.ToList();
            _facingImage = new ImageBox
            {
                Transform = new Transform2(new Vector2((1600 - size.Width) / 2, 900 - size.Height), size),
                Image = image
            };
            _newDialogIcon = new ImageBox
            {
                Transform = new Transform2(new Vector2(WhereAreYouStanding().Size.Width -50, -20), new Size2(36, 36)),
                Image = "UI/NewRedIconBorderless"
            };
        }

        public IReadOnlyList<Dialog> GetDialogs()
        {
            return _dialogs.Where(x => x.IsActive()).OrderBy(x => !x.IsNew).ToList();
        }

        public bool IsImmediatelyTalking()
        {
            return _dialogs.Any(d => d.IsNew && d.IsImmediatelyStarted());
        }

        public void StartImmediatelyTalking(Action<string[]> onStart)
        {
            _dialogs.First(d => d.IsNew && d.IsImmediatelyStarted()).StartImmediateDialog(onStart);
        }

        public void DrawTalking()
        {
            _facingImage.Draw(Transform2.Zero);
        }

        public void DrawNewIconIfApplicable()
        {
            if (GetDialogs().Any(d => d.IsNew))
                _newDialogIcon.Draw(new Transform2(WhereAreYouStanding().Location));
        }

        public abstract string WhereAreYou();
        public abstract Transform2 WhereAreYouStanding();
    }
}
