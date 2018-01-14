using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CATObjects
{
    public static class IsotopeDataLoader
    {
        public static IEnumerable<IsotopeProperties> LoadDataFile(string filepath)
        {
            return LoadFile(filepath)?.ExtractIsotopeDataNodes();
        }

        public static List<Isotope> LoadDrumInitFile(string filepath)
        {
            return LoadFile(filepath)?.ExtractInitialDrumInformation().ToList();
        }

        private static XmlDocument LoadFile(string path)
        {
            XmlDocument xDoc = null;

            if (!string.IsNullOrEmpty(path))
            {
                xDoc = new XmlDocument();
                xDoc.Load(path);
            }

            return xDoc;
        }

        private static IEnumerable<IsotopeProperties> ExtractIsotopeDataNodes(this XmlDocument xDoc)
        {
            // Extract the isotope nodes from the loaded XML file.
            if(xDoc.HasChildNodes)
            {
                foreach(XmlElement element in xDoc.ChildNodes)
                {
                    if(element.Name == "IsotopePropertySet")
                    {
                        yield return IsotopeProperties.LoadFromFile(element);
                    }
                }
            }
        }

        private static IEnumerable<Isotope> ExtractInitialDrumInformation(this XmlDocument xDoc)
        {
            // Extract the isotope nodes from the loaded XML file.
            if (xDoc.HasChildNodes)
            {
                foreach (XmlElement element in xDoc.ChildNodes)
                {
                    if (element.Name == "Isotope")
                    {
                        yield return Isotope.LoadFromFile(element);
                    }
                }
            }
        }
    }
}
