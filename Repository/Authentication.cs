using EffortTracker.Data;
using EffortTracker.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EffortTracker.Data;
namespace EffortTracker.Repository
{
    public class Authentication : IAuthentication
    {
        private readonly Context _context;
        private readonly string _key;

        public Authentication(Context context, string key)

        {
            _context = context;
            _key = key;
        }

        public string AuthenticationUser(int associate_id, string password)

        {
            var r = _context.Users.FirstOrDefault(t => t.associate_id == associate_id && t.password == password);
            if (r == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                        {
                            new Claim("associate_id", associate_id.ToString()),
                            //new Claim(ClaimTypes.Role, role)
                        }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

    }

}

