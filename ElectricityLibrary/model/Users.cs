using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class Users
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int ApartmentId { get; set; }
        public int CommunityId { get; set; }

        public Users()
        {

        }

        public Users(int userId, string? userName, string? password, int apartmentId, int communityId)
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
