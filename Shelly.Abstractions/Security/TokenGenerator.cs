using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shelly.Abstractions.Security
{
     public static class TokenGenerator
     {
          private const string SecretKey = "ygUVlLvyqru96T04CNN9KFypuJWzj4KN";
          public static string GenerateTokenJwt(string email, string userId)
          {
               SymmetricSecurityKey securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(SecretKey));
               SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
               JwtHeader header = new JwtHeader(signingCredentials);
               // create a claimsIdentity
               Claim[] claimsIdentity = 
               { 
                    new Claim(ClaimTypes.Email, email), 
                    new Claim(ClaimTypes.Sid, userId) 
               };
               JwtPayload payload = new JwtPayload(
                       issuer: "http://Shelly/",
                       audience: "http://Shelly/",
                       claims: claimsIdentity,
                       notBefore: DateTime.UtcNow,                       
                       expires: DateTime.UtcNow.AddDays(1)//// Exipra a la 24 horas.
                   );               
               JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(header,payload);
               return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
          }
          public static bool ValidateToken(string token, string userId,string email)
          {
               if (string.IsNullOrEmpty (token))
                    return false;

               var tokenHandler = new JwtSecurityTokenHandler();
               var key = Encoding.ASCII.GetBytes(SecretKey);
               try
               {
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(key),
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                         ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
                    var tokenUserId = jwtToken.Claims.First(x => x.Type == ClaimTypes.Sid).Value;
                    var tokenEmail = jwtToken.Claims.First(x => x.Type == ClaimTypes.Email).Value;
                    if(tokenUserId != userId)
                         return false;
                    if (tokenEmail != email)
                         return false;
                    // return user id from JWT token if validation successful
                    return true;
               }
               catch
               {
                    // return null if validation fails
                    return false;
               }
          }
     }
}
