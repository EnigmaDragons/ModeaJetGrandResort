using MonoDragons.Core.Inputs;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Engine;
using SpaceResortMurder.State;

namespace SpaceResortMurder.Scenes
{
    public sealed class Logo : IScene
    {
        private readonly string _nextScene;

        private ClickUI _clickUI;
        private bool _transitionComplete;
        private Timer _untilTransition;

        public Logo(string nextScene = "Intro")
        {
            _nextScene = nextScene;
        }

        public void Init()
        {
            _clickUI = new ClickUI();
            _clickUI.Add(new ScreenClickable(NavigateToMainMenu));
            _untilTransition = new Timer(NavigateToMainMenu, 8000);
            Input.ClearTransientBindings();
            Input.On(Control.Start, NavigateToMainMenu);
            Input.On(Control.A, NavigateToMainMenu);
            Audio.PlayMusicOnce("Logo", 1);
        }

        private void NavigateToMainMenu()
        {
            if (_transitionComplete)
                return;

            _transitionComplete = true;
            Audio.StopAllSound();
            Scene.NavigateTo(_nextScene);
        }

        public void Update(TimeSpan delta)
        {
            _clickUI.Update(delta);
            _untilTransition.Update(delta);
        }

        public void Draw()
        {
            UI.DrawCentered("Images/Logo/enigmadragons-presents");
        }

        public void Dispose()
        {
        }
    }
}