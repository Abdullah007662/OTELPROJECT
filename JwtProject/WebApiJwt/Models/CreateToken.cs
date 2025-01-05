using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            // Daha uzun bir key oluşturun çünkü bizim configürasyon yaptıgımıız program.cs de uzunluk yetersiz oldugu için keyde yetersiz oluyor ve hata verşiyor
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapikeymustbelonger!");

            // Güvenlik anahtarını oluşturun
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            // Kimlik doğrulama için imzalama kimlik bilgilerini oluşturun
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // JWT token oluşturun
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "http://localhost",
                audience: "http://localhost",
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(20),
                signingCredentials: signingCredentials
            );

            // Token'ı serileştirin
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
        public string CreateTokenAdmin()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapikeymustbelonger!");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim (ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"Visitor")
            };
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "http://localhost",
               audience: "http://localhost",
               notBefore: DateTime.Now,
               expires: DateTime.Now.AddSeconds(20),
               signingCredentials: signingCredentials,
               claims:claims
                  );


            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);

        }
    }
}
