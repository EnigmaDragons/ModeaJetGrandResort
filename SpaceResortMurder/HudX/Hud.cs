using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;

namespace SpaceResortMurder.HudX
{
    public class Hud
    {
        private List<VisualClickableUIElement> _clickables;

        public ClickUIBranch HudBranch { get; private set; }

        public void Init()
        {
            _clickables = new List<VisualClickableUIElement>();
            AddButton(() => Scene.NavigateTo(GameResources.DilemmasSceneName), "Dilemmas");
            AddButton(() => Scene.NavigateTo(GameResources.MapSceneName), "Map");
            AddButton(() => Scene.NavigateTo(GameResources.ObjectivesSceneName), "Objectives");
            HudBranch = new ClickUIBranch("HUD", 2);
            _clickables.ForEach(x => HudBranch.Add(x));
        }

        public void Draw()
        {
            _clickables.ForEach(x => x.Draw(Transform2.Zero));
        }

        private void AddButton(Action onClick, string name)
        {
            _clickables.Add(new TextButton(new Rectangle(1600 - (130 * (_clickables.Count + 1)), 0, 120, 40), onClick, name,
                Color.Green, Color.GreenYellow, Color.LightGreen));
        }
    }
}
