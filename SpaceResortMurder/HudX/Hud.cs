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
        private ImageBox _newObjectiveLabel;
        private ImageBox _newDilemmaOrAnswerLabel;

        public ClickUIBranch HudBranch { get; private set; }

        public void Init()
        {
            _clickables = new List<VisualClickableUIElement>();
            AddButton(() => Scene.NavigateTo(GameResources.DilemmasSceneName), "Dilemmas");
            AddButton(() => Scene.NavigateTo(GameResources.MapSceneName), "Map");
            AddIconButton(() => Scene.NavigateTo(GameResources.ObjectivesSceneName), "Icons/Objective");
            AddButton(() => Scene.NavigateTo(GameResources.DialogMemoriesScene), "Review");
            HudBranch = new ClickUIBranch("HUD", 2);
            _clickables.ForEach(x => HudBranch.Add(x));
            _newDilemmaOrAnswerLabel = new ImageBox
            {
                Transform = new Transform2(new Vector2(1550, 0), new Size2(36, 36)),
                Image = "UI/NewRedIconBorderless"
            };
            _newObjectiveLabel = new ImageBox
            {
                Transform = new Transform2(new Vector2(1290, 0), new Size2(36, 36)),
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
                _newObjectiveLabel.Draw(parentTransform);
            if (GameObjects.Dilemmas.GetActiveDilemmas().Any(d => d.IsNew || d.HasNewAnswers))
                _newDilemmaOrAnswerLabel.Draw(parentTransform);
        }

        private void AddIconButton(Action onClick, string name)
        {
            _clickables.Add(UiButtons.LargeIcon(new Vector2(1600 - 72 - 20, (_clickables.Count + 1) * 80), name, onClick));
        }

        private void AddButton(Action onClick, string name)
        {
            _clickables.Add(new TextButton(new Rectangle(1600 - (130 * (_clickables.Count + 1)), 20, 120, 40), onClick, name,
                Color.Green, Color.GreenYellow, Color.LightGreen));
        }
    }
}
