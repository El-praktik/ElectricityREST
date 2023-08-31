using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class Measure
    {
        public int MeasureId { get; set; }
        public double PowerUsed { get; set; }
        public double PowerGenerated { get; set; }
        public int CommunityId { get; set; }
        public int ApartmentId { get; set; }

        public Measure()
        {
            
        }

        public Measure(int measureId, double powerUsed, double powerGenerated, int communityId, int apartmentId)
        {
            MeasureId = measureId;
            PowerUsed = powerUsed;
            PowerGenerated = powerGenerated;
            CommunityId = communityId;
            ApartmentId = apartmentId;
        }

        public override string ToString()
        {
            return $"{nameof(MeasureId)}: {MeasureId}, {nameof(PowerUsed)}: {PowerUsed}, {nameof(PowerGenerated)}: {PowerGenerated}, {nameof(CommunityId)}: {CommunityId}, {nameof(ApartmentId)}: {ApartmentId}";
        }
    }
}
