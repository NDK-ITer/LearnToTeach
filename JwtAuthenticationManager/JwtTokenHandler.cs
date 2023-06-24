using JwtAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "NguyenDuyKhuongBirthdayIs12082002SpecialNameIsNDK";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private List<UserAccount> _userAccounts;

        public JwtTokenHandler()
        {
            //It will be got form database
            _userAccounts = new List<UserAccount>
            {
                new UserAccount{ UserName = "admin" , Password = "admin123", Role = "Administrator" },
                new UserAccount{ UserName = "user01", Password = "user01", Role = "User"},
            }; 
        }

        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest authenticationRequest)
        {
            //check authenticationRequest
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password))
            {
                return null;
            }
            //check user has available
            var userAccount = _userAccounts
                .Where(c => c.UserName == authenticationRequest.UserName && c.Password == authenticationRequest.Password)
                .FirstOrDefault();
            if (userAccount == null) { return null; }

            //set up timeout for token
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName),
                new Claim(ClaimTypes.Role, userAccount.Role),
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateJwtSecurityToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = authenticationRequest.UserName,
                JwtToken = token,
                ExpirensIn = (int) tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
            };
        }
    }
}
