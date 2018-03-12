﻿using System;
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
            HudBranch = new ClickUIBranch("HUD", 2);
            _clickables.ForEach(x => HudBranch.Add(x));
            _newIcon = new ImageBox
            {
                Transform = new Transform2(new Size2(36, 36)),
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
                _newIcon.Draw(new Transform2(GetLocation(0)));
            if (GameObjects.Dilemmas.GetActiveDilemmas().Any(d => d.IsNew || d.HasNewAnswers))
                _newIcon.Draw(new Transform2(GetLocation(2)));
        }

        private void AddIconButton(Action onClick, string name)
        {
            _clickables.Add(UiButtons.LargeIcon(new Vector2(1600 - 72 - 20, 20 +_clickables.Count * 88), name, onClick));
        }

        private Vector2 GetLocation(int index)
        {
            return new Vector2(1600-36, index * 88 + 40);
        }
    }
}
