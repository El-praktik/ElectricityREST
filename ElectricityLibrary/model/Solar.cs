using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class Solar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? SID { get; set; }
        [Required]
        public DateTime FromTime { get; set; }
        [Required]
        public double PowerGenerated { get; set; }
        public int BID { get; set; }

        public Solar()
        {

        }

        public Solar(int? solarId, DateTime fromTime, double powerGenerated, int blockId)
        {
            SID = solarId;
            FromTime = fromTime;
            PowerGenerated = powerGenerated;
            BID = blockId;
        }
        /*
        public override string ToString()
        {
            return $"{nameof(MID)}: {MID}, {nameof(PowerUsed)}: {PowerUsed}, {nameof(PowerGenerated)}: {PowerGenerated}, {nameof(CID)}: {CID}, {nameof(AID)}: {AID}";
        }
        */
    }
}
