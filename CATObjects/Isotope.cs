using System;
using System.Xml;

namespace CATObjects
{
    public class Isotope
    {
        public IsotopeProperties Details { get; set; }
        public IsotopeState State { get; private set; }

        internal static Isotope LoadFromFile(XmlElement element)
        {
            throw new NotImplementedException();
        }

        public void Decay(double timeStep)
        {
            throw new NotImplementedException("Add decay method.");

            //State.Activity = 0;
            //State.Number = 0;
        }
    }
}