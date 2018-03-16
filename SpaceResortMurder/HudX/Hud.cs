using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System.Linq;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using SpaceResortMurder.Style;
using MonoDragons.Core.Graphics;

namespace SpaceResortMurder.HudX
{
    public sealed class Hud : IVisual
    {
        private List<VisualClickableUIElement> _clickables;
        private ImageBox _newIcon;
        private Label _tooltipLabel;
        private ClickUIBranch _confirmationBranch;
        private bool _isConfirming = false;
        private List<IVisual> _confirmationVisuals;

        public ClickUIBranch HudBranch { get; private set; }

        public void Init()
        {
            _tooltipLabel = new Label
            {
                Transform = new Transform2(new Vector2(1270, 124), new Size2(500, 60)),
                BackgroundColor = Color.Transparent,
                HorizontalAlignment = HorizontalAlignment.Right,
                TextColor = UiStyle.TextLightPurple,
                Text = "Set [T]ooltip Here"
            };

            _confirmationVisuals = new List<IVisual>();
            _confirmationBranch = new ClickUIBranch("Confirm", 3);
            AddConfirmationButton(UiButtons.MenuRed("Quit", new Vector2(960 - 360 - 100, 500), Confirm));
            AddConfirmationButton(UiButtons.MenuRed("Cancel", new Vector2(960 + 0 + 100, 500), Cancel));
            _confirmationBranch.Add(new ScreenClickable(() => { }));

            _clickables = new List<VisualClickableUIElement>();
            AddIconButton(() => Scene.NavigateTo(GameResources.DilemmasSceneName), "Icons/Dilemmas", "Dilemmas");
            AddIconButton(() => Scene.NavigateTo(GameResources.DialogueMemoriesScene), "Icons/Conversations", "Conversations");
            AddIconButton(() => Scene.NavigateTo(GameResources.OptionsSceneName), "Icons/Options", "Options");
            AddIconButton(() => OpenConfirmationMenu(), "Icons/ExitToMenu", "Main Menu");
            HudBranch = new ClickUIBranch("HUD", 2);
            _clickables.ForEach(x => HudBranch.Add(x));
            _newIcon = new ImageBox
            {
                Transform = new Transform2(new Size2(43, 43)),
                Image = "UI/NewRedIconBorderless"
            };

            Event.SubscribeForever(EventSubscription.Create<ActiveElementChanged>(x => _tooltipLabel.Text = x.NewElement.TooltipText, this));
        }

        private void AddConfirmationButton(VisualClickableUIElement button)
        {
            _confirmationBranch.Add(button);
            _confirmationVisuals.Add(button);
        }

        private void OpenConfirmationMenu()
        {
            _isConfirming = true;
            HudBranch.Add(_confirmationBranch);
        }

        private void Confirm()
        {
            Scene.NavigateTo(GameResources.MainMenuSceneName);
            _isConfirming = false;
            HudBranch.Remove(_confirmationBranch);
        }

        private void Cancel()
        {
            _isConfirming = false;
            HudBranch.Remove(_confirmationBranch);
        }

        public void Draw(Transform2 parentTransform)
        {
            _clickables.ForEach(x => x.Draw(parentTransform));
            DrawNewIconsIfApplicable();
            _tooltipLabel.Draw(parentTransform);
            if (_isConfirming)
            {
                UI.Darken();
                _confirmationVisuals.ForEach(x => x.Draw());
            }
        }
        
        private void DrawNewIconsIfApplicable()
        {
            if (GameObjects.Dilemmas.GetActiveDilemmas().Any(d => d.IsNew || d.HasNewAnswers))
                _newIcon.Draw(new Transform2(GetIndicatorLocation(0)));
        }

        private void AddIconButton(Action onClick, string name, string tooltip)
        {
            _clickables.Add(UiButtons.Icon(new Vector2(1920 - 102, 12 + _clickables.Count * 106), name, onClick, tooltip));
        }

        private Vector2 GetIndicatorLocation(int index)
        {
            return new Vector2(1920 - 36, index * 106 + 26);
        }
    }
}
