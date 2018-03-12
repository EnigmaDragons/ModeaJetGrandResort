using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResortMurder.State
{
    public class Options
    {
        public static Options Instance;
        public bool IsFullscreen { get; set; } = false;
    }
}
