using MonoDragons.Core.Inputs;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using System;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Engine;

namespace SpaceResortMurder.Scenes
{
    public sealed class Logo : IScene
    {
        private readonly string _nextScene;
        
        private bool _transitionComplete;
        private Timer _untilTransition;

        public Logo(string nextScene = "Intro")
        {
            _nextScene = nextScene;
        }

        public void Init()
        {
            _untilTransition = new Timer(NavigateToMainMenu, 6000);
            Input.ClearTransientBindings();
            Input.On(Control.Start, NavigateToMainMenu);
            Audio.PlayMusicOnce("Logo", 0.5f);
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
            _untilTransition.Update(delta);
        }

        public void Draw()
        {
            UI.DrawCentered("Images/Logo/enigmadragons-presents");
        }
    }
}