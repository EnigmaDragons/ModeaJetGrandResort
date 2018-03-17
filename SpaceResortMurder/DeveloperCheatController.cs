using System;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Common;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Scenes;
using SpaceResortMurder.State;

namespace SpaceResortMurder
{
    public class DeveloperCheatController : IController
    {
        private readonly IController _controller;
        private bool _investigateEverythingCheatEnabled = false;
        private bool _goToResolutionCheatEnabled = false;

        public DeveloperCheatController(IController controller)
        {
            _controller = controller;
        }

        public void Subscribe(ISubscription<ControlChange> subscription)
        {
            _controller.Subscribe(subscription);
        }

        public void Unsubscribe(ISubscription<ControlChange> subscription)
        {
            _controller.Unsubscribe(subscription);
        }

        public void Subscribe(ISubscription<Direction> subscription)
        {
            _controller.Subscribe(subscription);
        }

        public void Unsubscribe(ISubscription<Direction> subscription)
        {
            _controller.Unsubscribe(subscription);
        }

        public void UnsubscribeAll()
        {
            _controller.UnsubscribeAll();
        }

        public void Update(TimeSpan delta)
        {
            _controller.Update(delta);
            var keys = Keyboard.GetState().GetPressedKeys().ToList();
            if (!_investigateEverythingCheatEnabled && keys.Contains(Keys.LeftControl) && keys.Contains(Keys.Z) && keys.Contains(Keys.X))
                CheatInvestigateEverything();
            if (!_goToResolutionCheatEnabled && keys.Contains(Keys.LeftControl) && keys.Contains(Keys.Z) && keys.Contains(Keys.C))
            {
                if (!_investigateEverythingCheatEnabled)
                    CheatInvestigateEverything();
                Scene.NavigateTo(GameResources.ResolutionSceneName);
                _goToResolutionCheatEnabled = true;
            }
        }

        public void ClearBindings()
        {
            _controller.ClearBindings();
        }

        private void CheatInvestigateEverything()
        {
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.Namespace.StartsWith("SpaceResortMurder.Clues.")
                            || x.Namespace.StartsWith("SpaceResortMurder.Dialogues.")
                            || x.Namespace.StartsWith("SpaceResortMurder.CharactersX"))
                .Select(x => x.Name)
                .ForEach(x =>
                {
                    Event.Publish(new ThoughtGained(x));
                    Event.Publish(new ItemViewed(x));
                });
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.Namespace.StartsWith("SpaceResortMurder.Deductions.")
                            || x.Namespace.StartsWith("SpaceResortMurder.DilemmasX")
                            || x.Namespace.StartsWith("SpaceResortMurder.LocationsX"))
                .Select(x => x.Name)
                .ForEach(x => Event.Publish(new ItemViewed(x)));
            _investigateEverythingCheatEnabled = true;
        }
    }
}
