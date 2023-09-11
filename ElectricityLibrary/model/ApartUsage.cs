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
        public int? AID { get; set; }
        [Required]
        public DateTime FromTime { get; set; }
        [Required]
        public DateTime ToTime { get; set; }
        [Required]
        public string PowerUsed { get; set; }
        [Required]
        public int Apartment { get; set; }

        public ApartUsage()
        {
            
        }

        public ApartUsage(int? Id, DateTime fromTime, DateTime toTime, string powerUsed, int apartmentId)
        {
            AID = Id;
            FromTime = fromTime;
            ToTime = toTime;
            PowerUsed = powerUsed;
            Apartment = apartmentId;
        }

        public override string ToString()
        {
            return $"{nameof(AID)}: {AID}, {nameof(FromTime)}: {FromTime}, {nameof(ToTime)}: {ToTime}";
        }
    }
}
