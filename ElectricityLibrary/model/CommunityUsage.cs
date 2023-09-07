using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class CommunityUsage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CommunityId { get; set; }
        [Required]
        public DateTime FromTime { get; set; }
        [Required]
        public DateTime ToTime { get; set; }
        [Required]
        public string PowerUsed { get; set; }
        [Required]
        public string PowerGenerated { get; set; }

        public CommunityUsage()
        {
            
        }

        public CommunityUsage(int? communityId, DateTime fromTime, DateTime toTime, string powerUsed, string powerGenerated)
        {
            CommunityId = communityId;
            FromTime = fromTime;
            ToTime = toTime;
            PowerUsed = powerUsed;
            PowerGenerated = powerGenerated;
        }

        public override string ToString()
        {
            return $"{nameof(CommunityId)}: {CommunityId}, {nameof(FromTime)}: {FromTime}, {nameof(ToTime)}: {ToTime}, {nameof(PowerUsed)}: {PowerUsed}, {nameof(PowerGenerated)}: {PowerGenerated}";
        }
    }
}
