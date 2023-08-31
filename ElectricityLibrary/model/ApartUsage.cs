using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class ApartUsage
    {
        public int ApartmentId { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public double PowerUsed { get; set; }
        public int CommunityId { get; set; }
        public int MeasureId { get; set; }

        public ApartUsage()
        {
            
        }

        public ApartUsage(int apartmentId, DateTime fromTime, DateTime toTime, double powerUsed, int communityId, int measureId)
        {
            ApartmentId = apartmentId;
            FromTime = fromTime;
            ToTime = toTime;
            PowerUsed = powerUsed;
            CommunityId = communityId;
            MeasureId = measureId;
        }

        public override string ToString()
        {
            return $"{nameof(ApartmentId)}: {ApartmentId}, {nameof(FromTime)}: {FromTime}, {nameof(ToTime)}: {ToTime}, {nameof(PowerUsed)}: {PowerUsed}, {nameof(CommunityId)}: {CommunityId}, {nameof(MeasureId)}: {MeasureId}";
        }
    }
}
