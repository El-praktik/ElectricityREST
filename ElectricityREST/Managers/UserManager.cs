using ElectricityLibrary.model;
using ElectricityREST.JWTKeySecret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ElectricityREST.Managers
{
    
    public class UserManager
    {
        private ELDBContext _context;
        private readonly AppSettings _settings;
        public UserManager(ELDBContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _settings = options.Value;
        }
        public UserManager(IOptions<AppSettings> options)
        {
            _settings= options.Value;
        }
        public UserManager(ELDBContext context)
        { 
            _context = context;
        }
        public IEnumerable<Users> GetAllUsers() 
        {
            return _context.Users;
        }
        public Users GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == id);
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == model.Username);
            if (user == null)
            {
                return null;
            }
            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }
        private string GenerateJwtToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.UserName)
                    }),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        }

     //  !!! Below is here for refernce pls no delete yet !!!

        //public Users AuthenticateRegularUser(string UsernName, string Password)
        //{
        //    var user = _context.Users.SingleOrDefault(x => x.UserName == UsernName &&  x.Password == Password);
        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_settings.Secret);
        //    if (UsernName != "admin")
        //    {
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {

        //            Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
        //            {
        //            new Claim(ClaimTypes.Name, user.UserName)
        //            }),
        //            Expires = DateTime.UtcNow.AddYears(1),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        //        };
        //        var token = tokenHandler.CreateToken(tokenDescriptor);
        //        user.Token = tokenHandler.WriteToken(token);
        //        user.Password = null;
        //        return user;
        //    }
        //    if(UsernName== "admin")
        //    {
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //                new Claim(ClaimTypes.Name, user.UserName)
        //            }),
        //            Expires = DateTime.UtcNow.AddYears(1),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        //        };
        //        var token = tokenHandler.CreateToken(tokenDescriptor);
        //        user.Token = tokenHandler.WriteToken(token);
        //        user.Password = null;
        //        return user;
        //    }
        //    return user;
        //} 
    }

