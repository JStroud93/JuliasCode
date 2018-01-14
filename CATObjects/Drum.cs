using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATObjects
{
    public class Drum
    {
        public int NumberOfComponents { get; private set; }
        public List<Isotope> CurrentContents { get; private set; }
        public DrumHistory History { get; private set; }

        public int RecommendedTimeStep
        {
            get
            {
                throw new NotImplementedException("Add method to calculate recommended timestep");
            }
        }

        public Drum(List<Isotope> initialContents = null)
        {
            NumberOfComponents = initialContents?.Count ?? 0;
            CurrentContents = NumberOfComponents == 0 ? new List<Isotope>() : initialContents;

            History = new DrumHistory(new Drum(initialContents));
        }

        public Drum CreateHistoryMarker()
        {            
            Isotope[] contents = new Isotope[NumberOfComponents];
            CurrentContents.CopyTo(contents);
            return new Drum(contents.ToList());
        }

        public void Decay(double decayTime, int timeStep = 0)
        {
            if (timeStep == 0)
                timeStep = RecommendedTimeStep;

            int numberOfSteps = (int)Math.Ceiling(decayTime / timeStep);
            for (int i = 0; i < numberOfSteps; i++)
            {
                foreach (Isotope isotope in CurrentContents)
                {
                    isotope.Decay(timeStep);
                    History.AddLaterPoint(timeStep, this);
                }
            }
        }
    }
}
