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
        public double PowerUsed { get; set; }
        [Required]
        public double PowerGenerated { get; set; }
        
       // [ForeignKey("CommunityUsage")] add this later
        public int CID { get; set; }
        //[ForeignKey("ApartUsage")] add this later
        public int AID { get; set; }

        public Measure()
        {
            
        }

        public Measure(int? measureId, double powerUsed, double powerGenerated, int communityId, int apartmentId)
        {
            MID = measureId;
            PowerUsed = powerUsed;
            PowerGenerated = powerGenerated;
            CID = communityId;
            AID = apartmentId;
        }

        public override string ToString()
        {
            return $"{nameof(MID)}: {MID}, {nameof(PowerUsed)}: {PowerUsed}, {nameof(PowerGenerated)}: {PowerGenerated}, {nameof(CID)}: {CID}, {nameof(AID)}: {AID}";
        }
    }
}
