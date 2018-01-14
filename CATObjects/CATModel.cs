using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATObjects
{
    public class CATModel
    {
        public IEnumerable<IsotopeProperties> IsotopeData { get; set; }
        public Drum Drum { get; set; }

        public CATModel(IEnumerable<IsotopeProperties> data, List<Isotope> initialDrumContents = null)
        {
            IsotopeData = data;
            Drum = new Drum(initialDrumContents);
        }

        public void ExecuteDecay(int decayTime, int timeStep = -1)
        {
            Drum.Decay(decayTime, timeStep);
        }
    }
}
