﻿using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;
using SpaceResortMurder.Style;

namespace SpaceResortMurder.Scenes
{
    public sealed class MainMenuScene : JamScene
    {
        private const int yStart = 600;
        private const int yOff = 90;
        private const int colX = 80;

        protected override void OnInit()
        {
            Audio.PlayMusic("MainTheme", 1);
            CurrentGameState.Reset();
            Add(UiButtons.Menu("Start Game", new Vector2(colX, Height(0)), () => Scene.NavigateTo(GameResources.PickNameSceneName)));
            Add(UiButtons.Menu("Continue Game", new Vector2(colX, Height(1)), () => Scene.NavigateTo(GameResources.SaveLoadSceneName)));
            Add(UiButtons.Menu("Credits", new Vector2(colX, Height(2)), () => Scene.NavigateTo(GameResources.CreditsSceneName)));
            Add(UiButtons.Menu("Options", new Vector2(colX, Height(3)), () => Scene.NavigateTo(GameResources.OptionsSceneName)));
            Add(UiButtons.Menu("Exit Game", new Vector2(colX, Height(4)), () => CurrentGame.TheGame.Exit()));
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Locations/TitleScreenBg");
            World.Draw("UI/Title", new Transform2(new Vector2(418, 160), Rotation2.Default, new Size2(1134, 474), 0.7f));
            UI.DrawCenteredWithOffset("UI/Copyright", new Vector2(313, 32), new Vector2(744, 494));
        }

        protected override void DrawForeground()
        {
            UI.FillScreen("UI/MainMenuBorder");
        }

        private int Height(int index)
        {
            return yStart + (index * yOff);
        }
    }
}