using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Dialogues;
using MonoDragons.Core.Engine;

namespace SpaceResortMurder.CharactersX
{
    public abstract class Character
    {
        private readonly List<Dialogue> _dialogs;
        private ImageBox _newDialogIcon;

        public Size2 FacingSize { get; }
        public string Image { get; }
        public string Value { get; }

        protected Character(string character, Size2 size, params Dialogue[] dialogues)
        {
            Value = character;
            Image = GameResources.GetCharacterImage(Value, Expression.Default);
            _dialogs = dialogues.ToList();
            FacingSize = size;
        }

        public void Init()
        {
            _newDialogIcon = new ImageBox
            {
                Transform = new Transform2(new Vector2(WhereAreYouStanding().Size.Width - 60, -24), new Size2(43, 43)),
                Image = "UI/NewRedIconBorderless"
            };
        }

        public VisualClickableUIElement CreateButton(Action<Character> onClick, int i, int count)
        {
            return new ImageTextButton(new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 120 + i * 120), new Size2(1680, 86)),
                () => onClick(this), GameResources.GetCharacterName(Value),
                "Convo/NameLabel", "Convo/NameLabel", "Convo/NameLabel")
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 120 + i * 120),
                    new Size2(UI.OfScreenWidth(0.96f) - UI.OfScreenWidth(0.66f), 86)),
                TextAlignment = HorizontalAlignment.Left,
            };
        }

        public TintedImageBox CreateFacingImage(Expression expression)
        {
            return new TintedImageBox
            {
                Transform = new Transform2(new Vector2(UI.OfScreenWidth(0.62f), UI.OfScreenHeight(1.0f) - (int)(FacingSize.Height / 1.3)), FacingSize),
                Image = GameResources.GetCharacterImage(Value, expression)
            };
        }

        public IVisual CreateChatNameBox()
        {
            return new ImageLabel(new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 960), new Size2(1680, 86)), "Convo/NameLabel")
            {
                Text = GameResources.GetCharacterName(Value),
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(UI.OfScreenWidth(0.66f), 960),
                    new Size2(UI.OfScreenWidth(0.96f) - UI.OfScreenWidth(0.66f), 86))
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

        public void StartImmediatelyTalking(Action<DialogueElement[]> onStart)
        {
            _dialogs.First(d => d.IsNew && d.AutoPlay && d.IsActive()).StartImmediateDialog(onStart);
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
