using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Dialogues;

namespace SpaceResortMurder.CharactersX
{
    public abstract class Character
    {
        private readonly List<Dialogue> _dialogs;
        private readonly Size2 _size;
        private readonly string _displayName;
        private ImageBox _facingImage;
        private ImageBox _newDialogIcon;
        private ImageLabel _convoNameBox;

        public string Value { get; }
        public string Image { get; }

        protected Character(string character, string displayName, string image, Size2 size, params Dialogue[] dialogues)
        {
            Value = character;
            _displayName = displayName;
            Image = image;
            _dialogs = dialogues.ToList();
            _size = size;
        }

        public void Init()
        {
            _facingImage = new ImageBox
            {
                Transform = new Transform2(new Vector2(UI.OfScreenWidth(0.62f), UI.OfScreenHeight(1.0f) - (int)(_size.Height / 1.3)), _size),
                Image = Image
            };
            _newDialogIcon = new ImageBox
            {
                Transform = new Transform2(new Vector2(WhereAreYouStanding().Size.Width - 60, -24), new Size2(43, 43)),
                Image = "UI/NewRedIconBorderless"
            };
            _convoNameBox = new ImageLabel(new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 960), new Size2(1680, 86)), "Convo/NameLabel")
            {
                Text = _displayName,
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 960),
                    new Size2(UI.OfScreenWidth(0.96f) - UI.OfScreenWidth(0.66f), 86))
            };
        }

        public VisualClickableUIElement CreateButton(Action<Character> onClick, int i, int count)
        {
            return new ImageTextButton(new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 120 + i * 120), new Size2(1680, 86)),
                () => onClick(this), _displayName,
                "Convo/NameLabel", "Convo/NameLabel", "Convo/NameLabel")
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 120 + i * 120),
                    new Size2(UI.OfScreenWidth(0.96f) - UI.OfScreenWidth(0.66f), 86)),
                TextAlignment = HorizontalAlignment.Left
            };
        }

        public IReadOnlyList<Dialogue> GetNewDialogs()
        {
            return _dialogs.Where(x => x.IsActive() && x.IsNew).ToList();
        }

        public IReadOnlyList<Dialogue> GetOldDialogs()
        {
            return _dialogs.Where(x => !x.IsNew).ToList();
        }

        public bool IsImmediatelyTalking()
        {
            return _dialogs.Any(d => d.IsNew && d.AutoPlay && d.IsActive());
        }

        public void StartImmediatelyTalking(Action<string[]> onStart)
        {
            _dialogs.First(d => d.IsNew && d.AutoPlay && d.IsActive()).StartImmediateDialog(onStart);
        }

        public void DrawTalking()
        {
            _facingImage.Draw(Transform2.Zero);
            _convoNameBox.Draw(Transform2.Zero);
        }

        public void DrawNewIconIfApplicable()
        {
            if (GetNewDialogs().Count != 0)
                _newDialogIcon.Draw(new Transform2(WhereAreYouStanding().Location));
        }
        
        public abstract string WhereAreYou();
        public abstract Transform2 WhereAreYouStanding();
    }
}
