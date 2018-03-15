using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResortMurder.State
{
    public class DialogMemoryGained
    {
        public string Dialog { get; }
        public string Location { get; }

        public DialogMemoryGained(string dialog, string location)
        {
            Dialog = dialog;
            Location = location;
        }
    }
}
