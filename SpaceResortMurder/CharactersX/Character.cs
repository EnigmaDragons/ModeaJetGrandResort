using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Dialogs;
using MonoDragons.Core.Render;

namespace SpaceResortMurder.CharactersX
{
    public abstract class Character
    {
        private readonly ImageBox _facingImage;
        private readonly List<Dialog> _dialogs;
        private readonly ImageBox _newDialogIcon;
        private readonly ImageLabel _convoNameBox;

        public string Image { get; }

        protected Character(string displayName, string image, Size2 size, params Dialog[] dialogs)
        {
            Image = image;
            _dialogs = dialogs.ToList();
            _facingImage = new ImageBox
            {
                Transform = new Transform2(new Vector2(UI.ConvertWidthPercentageToPixels(0.62f), UI.ConvertHeightPercentageToPixels(1.0f) - (int)(size.Height / 1.3)), size),
                Image = image
            };
            _newDialogIcon = new ImageBox
            {
                Transform = new Transform2(new Vector2(WhereAreYouStanding().Size.Width -50, -20), new Size2(36, 36)),
                Image = "UI/NewRedIconBorderless"
            };
            _convoNameBox = new ImageLabel(new Transform2(new Vector2(CurrentDisplay.FullScreenRectangle.Width - 570, 816), new Size2(560, 64)), "Convo/NameLabel")
            {
                Text = displayName,
                TextColor = Color.White
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
            _convoNameBox.Draw(Transform2.Zero);
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
