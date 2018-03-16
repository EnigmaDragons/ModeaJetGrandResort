using MonoDragons.Core.EventSystem;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace SpaceResortMurder.State
{
    public class GameState
    {
        [JsonProperty]
        private readonly Dictionary<string, string> _memories = new Dictionary<string, string>();

        [JsonProperty]
        private readonly HashSet<string> _viewedItems = new HashSet<string>();
        [JsonProperty]
        private readonly HashSet<string> _thoughts = new HashSet<string>();
        public string CurrentLocation { get; set; } = GameResources.MainMenuSceneName;
        public string CurrentLocationImage { get; set; } = "";

        public GameState()
        {
            Event.SubscribeForever(EventSubscription.Create<ItemViewed>(x => ChangeState(() => _viewedItems.Add(x.Item)), this));
            Event.SubscribeForever(EventSubscription.Create<ThoughtGained>(x => ChangeState(() => _thoughts.Add(x.Thought)), this));
            Event.SubscribeForever(EventSubscription.Create<ThoughtLost>(x => ChangeState(() => _thoughts.Remove(x.Thought)), this));
            Event.SubscribeForever(EventSubscription.Create<DialogMemoryGained>(x => ChangeState(() =>
            {
                _viewedItems.Add(x.Dialog);
                _memories.Add(x.Dialog, x.Location);
            }), this));
        }

        public bool HasViewedItem(string item)
        {
            return _viewedItems.Contains(item);
        }

        public bool IsThinking(string thought)
        {
            return _thoughts.Contains(thought);
        }

        public string RememberLocation(string dialog)
        {
            return _memories[dialog];
        }

        private void ChangeState(Action action)
        {
            action();
            Event.Publish(new StateChanged());
        }
    }
}
