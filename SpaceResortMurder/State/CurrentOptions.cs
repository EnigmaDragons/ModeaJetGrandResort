using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResortMurder.State
{
    public static class CurrentOptions
    {
        public static Options Instance { get; private set; }

        static CurrentOptions()
        {
            Load();
        }

        public static void Reset()
        {
            Instance = new Options();
        }

        public static void Load()
        {
            Instance = GameObjects.IO.HasSave("options")
                ? GameObjects.IO.Load<Options>("options")
                : new Options();
        }
    }
}
