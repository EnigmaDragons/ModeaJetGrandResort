using MonoDragons.Core.EventSystem;
using Newtonsoft.Json;
using System.Collections.Generic;
using SpaceResortMurder.Deductions.VictimsIdentity;

namespace SpaceResortMurder
{
    public class GameState
    {
        public static GameState Instance { get; set; }

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
        public string CurrentLocation { get; set; } = "";

        public GameState()
        {
            Event.SubscribeForever(EventSubscription.Create<ItemViewed>(x => _viewedItems.Add(x.Item), this));
            Event.SubscribeForever(EventSubscription.Create<ThoughtGained>(x => _thoughts.Add(x.Thought), this));
            Event.SubscribeForever(EventSubscription.Create<ThoughtLost>(x => _thoughts.Remove(x.Thought), this));
        }

        public bool HasViewedItem(string item)
        {
            return _viewedItems.Contains(item);
        }

        public bool IsThinking(string thought)
        {
            return _thoughts.Contains(thought);
        }
    }
}
