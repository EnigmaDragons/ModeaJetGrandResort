using System;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Common;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.Inputs;
using SpaceResortMurder.Dialogues.Meleena;
using SpaceResortMurder.Dialogues.RaymondsClone;
using SpaceResortMurder.Dialogues.Travis;
using SpaceResortMurder.Dialogues.Zaid;
using SpaceResortMurder.State;

namespace SpaceResortMurder
{
    public class DeveloperCheatController : IController
    {
        private readonly IController _controller;
        private bool _investigateEverythingCheatEnabled = false;

        private bool _yesMeleenaCheatEnabled;
        private bool _noMeleenaCheatEnabled;
        private bool _yesZaidCheatEnabled;
        private bool _noZaidCheatEnabled;
        private bool _yesTravisCheatEnabled;
        private bool _noTravisCheatEnabled;
        private bool _yesRaymondsCloneCheatEnabled;
        private bool _noRaymondsCloneCheatEnabled;

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

            if (!_yesMeleenaCheatEnabled && keys.Contains(Keys.LeftControl) && keys.Contains(Keys.D1))
            {
                _yesMeleenaCheatEnabled = true;
                Event.Publish(new ThoughtGained(nameof(IWontReportDataRaven)));
                Event.Publish(new ThoughtLost(nameof(DeckersMakeTheWorldWorse)));
                _noMeleenaCheatEnabled = false;
            }
            else if (!_noMeleenaCheatEnabled && keys.Contains(Keys.LeftControl) && keys.Contains(Keys.D2))
            {
                _noMeleenaCheatEnabled = true;
                Event.Publish(new ThoughtGained(nameof(DeckersMakeTheWorldWorse)));
                Event.Publish(new ThoughtLost(nameof(IWontReportDataRaven)));
                _yesMeleenaCheatEnabled = false;
            }
            else if (!_yesZaidCheatEnabled && keys.Contains(Keys.LeftControl) && keys.Contains(Keys.D3))
            {
                _yesZaidCheatEnabled = true;
                Event.Publish(new ThoughtGained(nameof(IWontSealYourFate)));
                Event.Publish(new ThoughtLost(nameof(YouBroughtThisOnYourself)));
                _noZaidCheatEnabled = false;
            }
            else if (!_noZaidCheatEnabled && keys.Contains(Keys.LeftControl) && keys.Contains(Keys.D4))
            {
                _noZaidCheatEnabled = true;
                Event.Publish(new ThoughtGained(nameof(YouBroughtThisOnYourself)));
                Event.Publish(new ThoughtLost(nameof(IWontSealYourFate)));
                _yesZaidCheatEnabled = false;
            }
            else if (!_yesTravisCheatEnabled && keys.Contains(Keys.LeftControl) && keys.Contains(Keys.D5))
            {
                _yesTravisCheatEnabled = true;
                Event.Publish(new ThoughtGained(nameof(WontTurnYouInForRaymondsAction)));
                Event.Publish(new ThoughtLost(nameof(YouAreStillResposible)));
                _noTravisCheatEnabled = false;
            }
            else if (!_noTravisCheatEnabled && keys.Contains(Keys.LeftControl) && keys.Contains(Keys.D6))
            {
                _noTravisCheatEnabled = true;
                Event.Publish(new ThoughtGained(nameof(YouAreStillResposible)));
                Event.Publish(new ThoughtLost(nameof(WontTurnYouInForRaymondsAction)));
                _yesTravisCheatEnabled = false;
            }
            else if (!_yesRaymondsCloneCheatEnabled && keys.Contains(Keys.LeftControl) && keys.Contains(Keys.D7))
            {
                _yesRaymondsCloneCheatEnabled = true;
                Event.Publish(new ThoughtGained(nameof(YouCanKeepYourLife)));
                Event.Publish(new ThoughtLost(nameof(YouRanYourCompanyPoorly)));
                _noRaymondsCloneCheatEnabled = false;
            }
            else if (!_noRaymondsCloneCheatEnabled && keys.Contains(Keys.LeftControl) && keys.Contains(Keys.D8))
            {
                _noRaymondsCloneCheatEnabled = true;
                Event.Publish(new ThoughtGained(nameof(YouRanYourCompanyPoorly)));
                Event.Publish(new ThoughtLost(nameof(YouCanKeepYourLife)));
                _yesRaymondsCloneCheatEnabled = false;
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
