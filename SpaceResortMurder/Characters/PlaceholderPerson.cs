using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResortMurder.Characters
{
    public class PlaceholderPerson
    {
        public List<Conversation> conversations = new List<Conversation>();

        public PlaceholderPerson()
        {
            var firstConversation = new Conversation();
            conversations.Add(firstConversation);
            var secondConversation = new Conversation();
        }
    }
}
