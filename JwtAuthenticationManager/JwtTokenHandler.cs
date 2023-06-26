using JwtAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "NguyenDuyKhg120802WithMySpecialNameIsNDK";
        private const int JWT_TOKEN_VALIDITY = 20;
        private List<UserAccount> _userAccountList;
        public JwtTokenHandler()
        {
            _userAccountList = new List<UserAccount>()
            {
                new UserAccount() {Id = Guid.NewGuid(), UserName = "admin", Password = "admin", Role = "Admin"},
                new UserAccount() {Id = Guid.NewGuid(), UserName = "user01", Password = "user01", Role = "User"},
            };
        }

        public AuthenticationReponse? GenerateJwtToken(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password)) { return null; }
            //can be use data on database
            var userAccount = _userAccountList.Where(c => c.UserName == authenticationRequest.UserName && c.Password == authenticationRequest.Password).FirstOrDefault();
            if (userAccount == null) {  return null; }
            
            var tokenExprityTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, userAccount.Id.ToString()),
                new Claim(ClaimTypes.Role, userAccount.Role)
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExprityTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationReponse
            {
                Id = userAccount.Id,
                UserName = userAccount.UserName,
                ExpiresIn = (int)tokenExprityTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token,
            };
        }
    }
}
