using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Dialogs;

namespace SpaceResortMurder.CharactersX
{
    public abstract class Character
    {
        private readonly ImageBox _facingImage;
        private readonly List<Dialog> _dialogs;
        private readonly ImageBox _newDialogIcon;
        private readonly ImageLabel _convoNameBox;
        private readonly string _displayName;

        public string Image { get; }

        protected Character(string displayName, string image, Size2 size, params Dialog[] dialogs)
        {
            _displayName = displayName;
            Image = image;
            _dialogs = dialogs.ToList();
            _facingImage = new ImageBox
            {
                Transform = new Transform2(new Vector2(UI.OfScreenWidth(0.62f), UI.OfScreenHeight(1.0f) - (int)(size.Height / 1.3)), size),
                Image = image
            };
            _newDialogIcon = new ImageBox
            {
                Transform = new Transform2(new Vector2(WhereAreYouStanding().Size.Width -50, -20), new Size2(36, 36)),
                Image = "UI/NewRedIconBorderless"
            };
            _convoNameBox = new ImageLabel(new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 800), new Size2(1400, 72)), "Convo/NameLabel")
            {
                Text = displayName,
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 800),
                    new Size2(UI.OfScreenWidth(0.96f) - UI.OfScreenWidth(0.66f), 72))
            };
        }

        public VisualClickableUIElement CreateButton(Action<Character> onClick, int i, int count)
        {
            return new ImageTextButton(new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 100 + i * 100), new Size2(1400, 72)),
                () => onClick(this), _displayName,
                "Convo/NameLabel", "Convo/NameLabel", "Convo/NameLabel")
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 100 + i * 100),
                    new Size2(UI.OfScreenWidth(0.96f) - UI.OfScreenWidth(0.66f), 72)),
                TextAlignment = HorizontalAlignment.Left
            };
        }

        public IReadOnlyList<Dialog> GetNewDialogs()
        {
            return _dialogs.Where(x => x.IsActive() && x.IsNew).ToList();
        }

        public IReadOnlyList<Dialog> GetOldDialogs()
        {
            return _dialogs.Where(x => !x.IsNew).ToList();
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
            if (GetNewDialogs().Any(d => d.IsNew))
                _newDialogIcon.Draw(new Transform2(WhereAreYouStanding().Location));
        }
        
        public abstract string WhereAreYou();
        public abstract Transform2 WhereAreYouStanding();
    }
}
