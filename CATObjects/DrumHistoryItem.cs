using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATObjects
{
    public class DrumHistoryItem : IComparable
    {
        public int Time { get; private set; }
        public Drum Details { get; private set; }

        public DrumHistoryItem(int t, Drum contents)
        {
            Time = t;
            Details = contents.CreateHistoryMarker();
        }

        public int CompareTo(object obj)
        {
            DrumHistoryItem objToCompare = (DrumHistoryItem)obj;
            return Time.CompareTo(objToCompare.Time);
        }
    }


}
