using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System.Linq;
using MonoDragons.Core.Engine;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.HudX
{
    public sealed class Hud : IVisual
    {
        private List<VisualClickableUIElement> _clickables;
        private ImageBox _newIcon; 

        public ClickUIBranch HudBranch { get; private set; }

        public void Init()
        {
            _clickables = new List<VisualClickableUIElement>();
            AddIconButton(() => Scene.NavigateTo(GameResources.ObjectivesSceneName), "Icons/Objective");
            AddIconButton(() => Scene.NavigateTo(GameResources.MapSceneName), "Icons/Locations");
            AddIconButton(() => Scene.NavigateTo(GameResources.DilemmasSceneName), "Icons/Dilemmas");
            AddIconButton(() => Scene.NavigateTo(GameResources.DialogueMemoriesScene), "Icons/Conversations");
            AddIconButton(() => Scene.NavigateTo(GameResources.OptionsSceneName), "Icons/Options");
            AddIconButton(() => Scene.NavigateTo(GameResources.MainMenuSceneName), "Icons/ExitToMenu");
            HudBranch = new ClickUIBranch("HUD", 2);
            _clickables.ForEach(x => HudBranch.Add(x));
            _newIcon = new ImageBox
            {
                Transform = new Transform2(new Size2(43, 43)),
                Image = "UI/NewRedIconBorderless"
            };
        }

        public void Draw(Transform2 parentTransform)
        {
            _clickables.ForEach(x => x.Draw(parentTransform));
            DrawNewIconsIfApplicable(parentTransform);
        }

        private void DrawNewIconsIfApplicable(Transform2 parentTransform)
        {
            if (GameObjects.Objectives.GetActiveObjectives().Any(o => o.IsNew))
                _newIcon.Draw(new Transform2(GetIndicatorLocation(0)));
            if (GameObjects.Locations.GetAvailableLocations().Any(l => l.IsNewOrHasNewDialogs))
                _newIcon.Draw(new Transform2(GetIndicatorLocation(1)));
            if (GameObjects.Dilemmas.GetActiveDilemmas().Any(d => d.IsNew || d.HasNewAnswers))
                _newIcon.Draw(new Transform2(GetIndicatorLocation(2)));
        }

        private void AddIconButton(Action onClick, string name)
        {
            _clickables.Add(UiButtons.LargeIcon(new Vector2(1920 - 115, 12 + _clickables.Count * 106), name, onClick));
        }

        private Vector2 GetIndicatorLocation(int index)
        {
            return new Vector2(1920 - 36, index * 106 + 26);
        }
    }
}
