using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Graphics;
using MonoDragons.Core.Render;
using SpaceResortMurder.Style;
using MonoDragons.Core.Inputs;

namespace SpaceResortMurder.Scenes
{
    public class MainMenuScene : IScene
    {
        private TextButton _start;
        private TextButton _credits;
        private TextButton _options;
        private Texture2D _border;
        private ClickUI _clickUi;
        
        public void Init()
        {
            Input.ClearTransientBindings();
            Audio.PlayMusic("MainTheme");
            GameState.Instance = new GameState();
            _clickUi = new ClickUI();
            _start = new TextButton(new Rectangle(120, 610, 250, 60), () =>
                {
                    Audio.PlaySound("MenuButtonPress");
                    Scene.NavigateTo(GameObjects.RoomNames.BlackRoom);
                }, "Start Game",
                UiStyle.ButtonGreen, UiStyle.ButtonHoverGreen, UiStyle.ButtonPressedGreen);
            _credits = new TextButton(new Rectangle(120, 770, 250, 60), () =>
                {
                    Audio.PlaySound("MenuButtonPress");
                    Scene.NavigateTo(GameObjects.CreditsSceneName);
                }, "View Credits",
                UiStyle.ButtonGreen, UiStyle.ButtonHoverGreen, UiStyle.ButtonPressedGreen);
            _options = new TextButton(new Rectangle(120, 690, 250, 60), () =>
                {
                    Audio.PlaySound("MenuButtonPress");
                    GameState.Instance.CurrentLocation = "Main Menu";
                    Scene.NavigateTo(GameObjects.OptionsSceneName);
                },
                "Options",
                UiStyle.ButtonGreen, UiStyle.ButtonHoverGreen, UiStyle.ButtonPressedGreen);
            _clickUi.Add(_start);
            _clickUi.Add(_credits);
            _clickUi.Add(_options);
        }

        public void Update(TimeSpan delta)
        {
            _clickUi.Update(delta);
        }

        public void Draw()
        {
            UI.DrawCentered("UI/MainMenuBg", CurrentDisplay.Size);
            UI.Darken();
            World.Draw("characters/resort_manager_colored", new Vector2(700, 500));
            UI.DrawCenteredWithOffset("UI/Title", new Vector2(0, -150));
            UI.DrawCentered("UI/MainMenuBorder", CurrentDisplay.Size);

            _start.Draw(Transform2.Zero);
            _credits.Draw(Transform2.Zero);
            _options.Draw(Transform2.Zero);
        }
    }
}