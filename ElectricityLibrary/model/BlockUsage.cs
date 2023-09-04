using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class BlockUsage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? BlockId { get; set; }
        [Required]
        public DateTime FromTime { get; set; }
        [Required]
        public DateTime ToTime { get; set; }
        [Required]
        public double PowerUsed { get; set; }
        [Required]
        public double PowerGenerated { get; set; }
        [Required]
       // [ForeignKey("CommunityUsage")]
        public int CommunityId { get; set; }
        [Required]
       // [ForeignKey("ApartUsage")]
        public int ApartmentId { get; set; }

        public BlockUsage()
        {
            
        }

        public BlockUsage(int? blockId, DateTime fromTime, DateTime toTime, double powerUsed, double powerGenerated, int communityId, int apartmentId)
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
