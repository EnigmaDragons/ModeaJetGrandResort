using Microsoft.Xna.Framework;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;

namespace SpaceResortMurder.Scenes
{
    public class MainMenuScene : IScene
    {
        private ImageTextButton _start;
        private ImageTextButton _credits;
        private ImageTextButton _options;
        private ClickUI _clickUi;
        
        public void Init()
        {
            GameObjects.InitIfNeeded();
            Input.ClearTransientBindings();
            Audio.PlayMusic("MainTheme");
            GameState.Instance = new GameState();
            _clickUi = new ClickUI();
            _start = new ImageTextButton(new Rectangle(120, 610, 240, 50), () =>
                {
                    Audio.PlaySound("MenuButtonPress");
                    Scene.NavigateTo(GameObjects.RoomNames.BlackRoom);
                }, "Start Game",
                "UI/PixelButton", "UI/PixelButton-Hover", "UI/PixelButton-Press")
                { TextColor = Color.Black };
            _credits = new ImageTextButton(new Rectangle(120, 770, 240, 50), () =>
                {
                    Audio.PlaySound("MenuButtonPress");
                    Scene.NavigateTo(GameObjects.CreditsSceneName);
                }, "Credits", "UI/PixelButton", "UI/PixelButton-Hover", "UI/PixelButton-Press")
                { TextColor = Color.Black };
            _options = new ImageTextButton(new Rectangle(120, 690, 240, 50), () =>
                {
                    Audio.PlaySound("MenuButtonPress");
                    GameState.Instance.CurrentLocation = "Main Menu";
                    Scene.NavigateTo(GameObjects.OptionsSceneName);
                },
                "Options", "UI/PixelButton", "UI/PixelButton-Hover", "UI/PixelButton-Press")
                { TextColor = Color.Black };
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
            UI.FillScreen("UI/MainMenuBg");
            UI.Darken();
            World.Draw("characters/resort_manager_colored", new Vector2(700, 500));
            UI.DrawCenteredWithOffset("UI/Title", new Vector2(0, -150));
            UI.DrawCenteredWithOffset("UI/Copyright", new Vector2(261, 27), new Vector2(620, 412));

            _start.Draw(Transform2.Zero);
            _credits.Draw(Transform2.Zero);
            _options.Draw(Transform2.Zero);

            UI.FillScreen("UI/MainMenuBorder");
        }
    }
}