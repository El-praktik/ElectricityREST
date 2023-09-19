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
        public double PowerUsed { get; set; }
        public int AID { get; set; }

        public Measure()
        {
            
        }

        public Measure(int? measureId, DateTime fromTime, double powerUsed, int apartmentId)
        {
            MID = measureId;
            FromTime = fromTime;
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
