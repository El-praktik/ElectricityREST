using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Token { get; set; }
        [Required]
        // [ForeignKey("ApartUsage")]
        public int ApartmentId { get; set; }
        [Required]
        // [ForeignKey("CommunityUsage")]
        public int CommunityId { get; set; }
       

        public Users()
        {

        }

        public Users(int? userId, string userName, string password, int apartmentId, int communityId)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            ApartmentId = apartmentId;
            CommunityId = communityId;
        }

        public override string ToString()
        {
            return $"{nameof(UserId)}: {UserId}, {nameof(UserName)}: {UserName}, {nameof(Password)}: {Password}, {nameof(ApartmentId)}: {ApartmentId}, {nameof(CommunityId)}: {CommunityId}";
        }
    }
}
