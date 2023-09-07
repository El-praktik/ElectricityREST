using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class ApartUsage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ApartmentId { get; set; }
        [Required]
        public DateTime FromTime { get; set; }
        [Required]
        public DateTime ToTime { get; set; }
        [Required]
        public string PowerUsed { get; set; }
        [Required]
        //[ForeignKey("CommunityUsage")]
        public int CommunityId { get; set; }
        [Required]
        //[ForeignKey("Measure")]
        public int MeasureId { get; set; }

        public ApartUsage()
        {
            
        }

        public ApartUsage(int? apartmentId, DateTime fromTime, DateTime toTime, string powerUsed, int communityId, int measureId)
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
