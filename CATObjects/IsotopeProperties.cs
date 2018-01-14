using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CATObjects
{
    public class IsotopeProperties
    {
        public string Name { get; private set; }
        public double DecayRate { get; private set; }

        private IsotopeProperties(XmlElement element)
        {
            throw new NotImplementedException();
        }

        public static IsotopeProperties LoadFromFile(XmlElement element)
        {
            return new IsotopeProperties(element);
        }
    }
}
