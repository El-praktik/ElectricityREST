using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class Measure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? MID { get; set; }
        [Required]
        public DateTime FromTime { get; set; }
        [Required]
        public DateTime ToTime { get; set; }
        [Required]
        public int PowerUsed { get; set; }
        public int AID { get; set; }

        public Measure()
        {
            
        }

        public Measure(int? measureId, DateTime fromTime, DateTime toTime, int powerUsed, string powerGenerated, int apartmentId)
        {
            MID = measureId;
            FromTime = fromTime;
            ToTime = toTime;
            PowerUsed = powerUsed;
            AID = apartmentId;
        }
        /*
        public override string ToString()
        {
            return $"{nameof(MID)}: {MID}, {nameof(PowerUsed)}: {PowerUsed}, {nameof(PowerGenerated)}: {PowerGenerated}, {nameof(CID)}: {CID}, {nameof(AID)}: {AID}";
        }
        */
    }
}
