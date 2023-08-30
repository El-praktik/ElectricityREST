using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityLibrary.model
{
    public class Users
    {
        // TODO: complete the properties and methods
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public string? UserEmail { get; set; }
        public enum UserType
        {
            Admin,
            User
        }

        public Users()
        {
            
        }

        public Users(int userId, string userName, string userPassword, string userEmail)
        {
            UserId = userId;
            UserName = userName;
            UserPassword = userPassword;
            UserEmail = userEmail;
        }

        public override string ToString()
        {
            return $"UserId: {UserId}, UserName: {UserName}, UserPassword: {UserPassword}, UserEmail: {UserEmail}";
        }
    }
}
