using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class BlockUsage
    {
        public int BlockId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public double PowerUsed { get; set; }
        public double PowerGenerated { get; set; }
        public int CommunityId { get; set; }
        public int ApartmentId { get; set; }

        public BlockUsage()
        {
            
        }

        public BlockUsage(int blockId, DateTime fromTime, DateTime toTime, double powerUsed, double powerGenerated, int communityId, int apartmentId)
        {
            BlockId = blockId;
            FromTime = fromTime;
            ToTime = toTime;
            PowerUsed = powerUsed;
            PowerGenerated = powerGenerated;
            CommunityId = communityId;
            ApartmentId = apartmentId;
        }

        public override string ToString()
        {
            return $"{nameof(BlockId)}: {BlockId}, {nameof(FromTime)}: {FromTime}, {nameof(ToTime)}: {ToTime}, {nameof(PowerUsed)}: {PowerUsed}, {nameof(PowerGenerated)}: {PowerGenerated}, {nameof(CommunityId)}: {CommunityId}, {nameof(ApartmentId)}: {ApartmentId}";
        }
    }
}
