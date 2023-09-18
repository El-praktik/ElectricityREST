using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class AuthenticateResponse
    {
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public AuthenticateResponse(Users user, string token)
        {
            UserID = user.UserId;
            UserName = user.UserName;
            Password = user.Password;
            Token = token;
        }
    }
}
