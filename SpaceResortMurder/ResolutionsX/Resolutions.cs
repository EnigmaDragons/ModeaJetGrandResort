using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResortMurder.ResolutionsX
{
    public class Resolutions
    {
        private List<Resolution> _resolutions = new List<Resolution>()
        {
            new IAmLeaving(),
        };

        public IReadOnlyList<Resolution> GetAvailableResolutions()
        {
            return _resolutions.Where(d => d.IsActive()).ToList();
        }
    }
}
