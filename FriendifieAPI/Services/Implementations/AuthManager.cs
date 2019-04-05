using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FriendifieAPI.Configuration;
using FriendifieAPI.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FriendifieAPI.Services.Implementations
{
    public class AuthManager : IAuthManager
    {
        private readonly AppSettings _appSettings;
        private readonly SymmetricSecurityKey _signingKey;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public AuthManager(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.AuthSigningKey));
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string LoginUser(string email, string userId)
        {
            return GenerateAccessToken(email, userId);
        }

        private string GenerateAccessToken(string email, string userId)
        {
            var now = DateTime.UtcNow;
            var signingCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256Signature);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(_appSettings.UserClaim, _appSettings.UserClaimValue)
            }, "Custom");

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = _appSettings.AuthAudience,
                Issuer = "self",
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Expires = now.AddDays(Convert.ToInt32(_appSettings.JwtExpiry))
            };

            // Create token
            var plainToken = _tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = _tokenHandler.WriteToken(plainToken);
            return signedAndEncodedToken;
        }
    }
}