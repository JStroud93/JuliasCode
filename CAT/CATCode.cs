using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CATObjects;

namespace CAT
{
    public class CATCode
    {
        private CATModel m_Model = null;

        public CATCode(string dataFilePath, string drumInitPath = "")
        {
            m_Model = new CATModel(IsotopeDataLoader.LoadDataFile(dataFilePath), IsotopeDataLoader.LoadDrumInitFile(drumInitPath));
        }

        public int GetRecommendedTimeStep()
        {
            return m_Model.Drum.RecommendedTimeStep;
        }

    }
}
