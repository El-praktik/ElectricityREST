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
        public int? MeasureId { get; set; }
        [Required]
        public double PowerUsed { get; set; }
        [Required]
        public double PowerGenerated { get; set; }
        
       // [ForeignKey("CommunityUsage")] add this later
        public int CommunityId { get; set; }
        //[ForeignKey("ApartUsage")] add this later
        public int ApartmentId { get; set; }

        public Measure()
        {
            
        }

        public Measure(int? measureId, double powerUsed, double powerGenerated, int communityId, int apartmentId)
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
