using System.Collections.Generic;
using MonoDragons.Core.Animations;
using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Scenes;

namespace SpaceResortMurder.Credits
{
    public sealed class CreditsScene : JamScene
    {
        private readonly Queue<IAnimation> _animations = new Queue<IAnimation>();
        private TimerTask _timer;
        private bool _animationsAreFinished;

        protected override void OnInit()
        {
            GameObjects.InitIfNeeded();
            Audio.PlayMusicOnce("Credits");
            AddUi(new ScreenClickable(() => Scene.NavigateTo(GameResources.MainMenuSceneName)));

            AddAnimation(new EnigmaDragonsCredit());
            AddAnimation(new ProjectManagerCredit());
            AddAnimation(new GameDesignerCredit());
            AddAnimation(new LeadArtistCredit());
            AddAnimation(new ProgrammerCredit());
            AddAnimation(new UiDesignerCredit());
            AddAnimation(new CharacterArtistCredit());
            AddAnimation(new WriterCredit());
            AddAnimation(new EnvironmentArtPaintingCredit());
            AddAnimation(new EnvironmentArtConceptsCredit());
            AddAnimation(new ComposerCredit());

            _timer = new TimerTask(StartNext, 600, recurring: false);
            Add(_timer);
        }

        private void AddAnimation(IAnimation anim)
        {
            _animations.Enqueue(anim);
            Add(anim);
        }

        private void QueueNext()
        {
            _timer.Reset();
        }

        private void StartNext()
        {
            if (_animations.Count > 0)
                _animations.Dequeue().Start(QueueNext);
            else
                _animationsAreFinished = true;
        }

        protected override void DrawBackground()
        {
            if (_animationsAreFinished)
                UI.FillScreen("Images/Logo/oilsplash");
        }

        protected override void DrawForeground()
        {
        }
    }
}