using MonoDragons.Core.EventSystem;
using Newtonsoft.Json;
using System.Collections.Generic;
using SpaceResortMurder.Deductions.VictimsIdentity;
using System;

namespace SpaceResortMurder.State
{
    public class GameState
    {
        [JsonProperty]
        private readonly HashSet<string> _viewedItems = new HashSet<string>
        {
            nameof(TheVictimIsRaymond)
        };
        [JsonProperty]
        private readonly HashSet<string> _thoughts = new HashSet<string>
        {
            nameof(TheVictimIsRaymond)
        };
        public string CurrentLocation { get; set; } = GameResources.MainMenuSceneName;

        public GameState()
        {
            Event.SubscribeForever(EventSubscription.Create<ItemViewed>(x => ChangeState(() => _viewedItems.Add(x.Item)), this));
            Event.SubscribeForever(EventSubscription.Create<ThoughtGained>(x => ChangeState(() => _thoughts.Add(x.Thought)), this));
            Event.SubscribeForever(EventSubscription.Create<ThoughtLost>(x => ChangeState(() => _thoughts.Remove(x.Thought)), this));
        }

        public bool HasViewedItem(string item)
        {
            return _viewedItems.Contains(item);
        }

        public bool IsThinking(string thought)
        {
            return _thoughts.Contains(thought);
        }

        private void ChangeState(Action action)
        {
            action();
            Event.Publish(new StateChanged());
        }
    }
}
