using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATObjects
{
    public class DrumHistory
    {
        public List<DrumHistoryItem> Log { get; private set; }

        public DrumHistory(Drum initialDrumContents, int timeOffset = 0)
        {
            Log = new List<DrumHistoryItem>() { new DrumHistoryItem(timeOffset, initialDrumContents) };
        }

        public void AddLaterPoint(int passedTime, Drum currentContents)
        {
            Log.Add(new DrumHistoryItem(Log.Last().Time + passedTime, currentContents));
        }

        public void AddPeriod(DrumHistory historyToAdd)
        {
            // New entries with the same timestep value take precedence. Remove all pre-existing values.
            Log.RemoveAll(x => historyToAdd.Log.Exists(y => y.Time == x.Time));

            // Add new extension to history log.
            Log.AddRange(historyToAdd.Log);
            Log.Sort();
        }
    }
}
