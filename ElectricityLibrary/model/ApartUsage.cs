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
        public int BID { get; set; }

        public ApartUsage()
        {
            
        }

        public ApartUsage(int? Id, int powerUsedCurrentMonth, int powerUsedLastMonth, int BId)
        {
            AID = Id;
            BID = BId;
        }
        /*
        public override string ToString()
        {
            return $"{nameof(AID)}: {AID}, {nameof(FromTime)}: {FromTime}, {nameof(ToTime)}: {ToTime}";
        }
        */
    }
}
