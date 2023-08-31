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
    }
}
