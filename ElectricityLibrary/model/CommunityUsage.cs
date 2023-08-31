using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class CommunityUsage
    {
        public int CommunityId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public double PowerUsed { get; set; }
        public double PowerGenerated { get; set; }

        public CommunityUsage()
        {
            
        }

        public CommunityUsage(int communityId, DateTime fromTime, DateTime toTime, double powerUsed, double powerGenerated)
        {
            CommunityId = communityId;
            FromTime = fromTime;
            ToTime = toTime;
            PowerUsed = powerUsed;
            PowerGenerated = powerGenerated;
        }

        public override string ToString()
        {
            return $"{nameof(CommunityId)}: {CommunityId}, {nameof(FromTime)}: {FromTime}, {nameof(ToTime)}: {ToTime}, {nameof(PowerUsed)}: {PowerUsed}, {nameof(PowerGenerated)}: {PowerGenerated}";
        }
    }
}
